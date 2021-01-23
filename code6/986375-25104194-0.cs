    public void SendMail(MailAddress @from, MailAddress[] to, string subject, AlternateView[] alternateMessageBodyViews, Attachment[] attachments)
        {
            _validationService.StringIsNullOrEmpty(subject, "subject");
            _validationService.Null(from, "from");
            _validationService.StringIsNullOrEmpty(from.Address, "from.Address");
            _validationService.Null(to, "to");
            /* Important Notice
             * SendGrid has 20480000 bytes limitation for the total message size. Approx. 19.5 MB
             * BUT attachments are Base64 encoded therefore 15MB of attachments will actually become 20 MB when encoded.
             * Therefore we need to cut down the attachments total ( cumulative ) size to 12 MB which will make 16 MB after base64
             * Combined with other message information like message headers, attachments headers, etc. will keep us away from the 19.5MB limit
             */
            long approximateTotalMessageMaxSizeInBytes = 0;
            MailMessage mailMsg = new MailMessage();
            // From
            mailMsg.From = new MailAddress(from.Address, from.DisplayName);
            approximateTotalMessageMaxSizeInBytes += Convert.ToBase64String(Encoding.UTF8.GetBytes(from.Address)).Length;
            approximateTotalMessageMaxSizeInBytes += Convert.ToBase64String(Encoding.UTF8.GetBytes(from.DisplayName)).Length;
            // To
            foreach (MailAddress toMailAddress in to)
            {
                mailMsg.To.Add(new MailAddress(toMailAddress.Address, toMailAddress.DisplayName));
                approximateTotalMessageMaxSizeInBytes += Convert.ToBase64String(Encoding.UTF8.GetBytes(toMailAddress.Address)).Length;
                approximateTotalMessageMaxSizeInBytes += Convert.ToBase64String(Encoding.UTF8.GetBytes(toMailAddress.DisplayName)).Length;
            }
            // Subject and multipart/alternative Body
            mailMsg.Subject = subject;
            approximateTotalMessageMaxSizeInBytes += Convert.ToBase64String(Encoding.UTF8.GetBytes(subject)).Length;
            if (alternateMessageBodyViews != null)
            {
                foreach (AlternateView alternateView in alternateMessageBodyViews)
                {
                    mailMsg.AlternateViews.Add(alternateView);
                    approximateTotalMessageMaxSizeInBytes += (long)(alternateView.ContentStream.Length * 1.33);
                }
            }
            if (attachments != null)
            {
                foreach (Attachment attachment in attachments)
                {
                    mailMsg.Attachments.Add(attachment);
                    approximateTotalMessageMaxSizeInBytes += (long)(attachment.ContentStream.Length * 1.33);
                }
            }
            if (approximateTotalMessageMaxSizeInBytes > long.Parse(ConfigurationManager.AppSettings["TotalMessageMaxSizeInBytes"]))
            {
                throw new MailMessageTooBigException(
                    string.Format("Message total bytes limit is {0}. This message is approximately {1} bytes long.",
                        approximateTotalMessageMaxSizeInBytes));
            }
            try
            {
                _mailSender.Send(mailMsg);
            }
            catch(Exception exception) // swallow the exception so the server do not blow up because of a third party service.
            {
                _logger.Exception("SendGridMailService", _currentUserProvider.CurrentUserId, exception);
            }
            string logFrom = string.Format("{0} <{1}>", from.DisplayName, from.Address);
            string[] logTo = to.Select(t => string.Format("{0} <{1}>", t.DisplayName, t.Address)).ToArray();
            string[] atts = (attachments == null) ? null : attachments.Select(att => att.Name).ToArray();
            _logger.SendEmail(
                _currentUserProvider.CurrentSystemUser.UserName,
                logFrom,
                logTo,
                subject,
                atts);
        }
