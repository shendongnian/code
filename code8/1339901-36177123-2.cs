            string aheading = "Defects:";
            string bheading = "Comments:";
            string result = string.Format("<table><tr><th>{0}</th><th>{1}</th></tr>", aheading, bheading);
            
            foreach (var item in chkList.CheckItems)
            {
                if (item.Defect == true)
                {
                    result += string.Format("<tr><td>{0}</td><td>{1}</td></tr>", item.ItemTitle.Trim(), item.Comment.Trim());
                }
            }
            result += "</table>";
            var message = new MailMessage();
            message.IsBodyHtml = true;
            message.Body = result;
            // SEND MESSAGE
            var client = new SmtpClient("mailhost");
            // If auth is needed
            client.Credentials = new NetworkCredential("username", "password");
            client.Send(message);
