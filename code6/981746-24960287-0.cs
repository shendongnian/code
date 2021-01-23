    var cmMsg = _ml.GetMessage(mId, session.AuthenticatedUserIdentity.Name, -1);
                MIME_h_ContentType contentType_multipartMixed = new MIME_h_ContentType(MIME_MediaTypes.Multipart.mixed);
                contentType_multipartMixed.Param_Boundary = Guid.NewGuid().ToString().Replace('-', '.');
                MIME_b_MultipartMixed multipartMixed = new MIME_b_MultipartMixed(contentType_multipartMixed);
                var msg = new Mail_Message();
                msg.To = new Mail_t_AddressList();
                msg.From = new Mail_t_MailboxList {new Mail_t_Mailbox(cmMsg.From, cmMsg.FromEmail)};
                msg.Cc = new Mail_t_AddressList();
                msg.Bcc = new Mail_t_AddressList();
                msg.Body = multipartMixed;
                foreach (var recipient in cmMsg.Recipients)
                {
                    if (recipient.isTo)
                    {
                        msg.To.Add(new Mail_t_Mailbox(recipient.FullName, recipient.SMTPAddress));
                    }
                    else if(recipient.isCC)
                    {
                        msg.Cc.Add(new Mail_t_Mailbox(recipient.FullName, recipient.SMTPAddress));
                    }
                    else if (recipient.isBCC)
                    {
                        msg.Bcc.Add(new Mail_t_Mailbox(recipient.FullName, recipient.SMTPAddress));
                    }
                }
                msg.Subject = cmMsg.Subject;
                msg.Date = cmMsg.TimeDate;
                msg.MessageID = cmMsg.InternetMessageId;
                msg.MimeVersion = "1.0";
                msg.Header.Add(new MIME_h_Unstructured("X-MS-Has-Attach", "yes"));
                if (e.FetchDataType == IMAP_Fetch_DataType.MessageStructure)
                {
                   
                }
                else if(e.FetchDataType == IMAP_Fetch_DataType.MessageHeader)
                {
                    
                }
                else
                {
                    MIME_Entity entity_text_plain = new MIME_Entity();
                    MIME_b_Text text_plain = new MIME_b_Text(MIME_MediaTypes.Text.plain);
                    entity_text_plain.Body = text_plain;
                    text_plain.SetText(MIME_TransferEncodings.QuotedPrintable, Encoding.UTF8, cmMsg.HtmlBody);
                    multipartMixed.BodyParts.Add(entity_text_plain);
                    foreach (var attachment in cmMsg.Attachments)
                    {
                        using (var fs = new FileStream(@"C:\test.txt", FileMode.Open))
                        {
                            multipartMixed.BodyParts.Add(Mail_Message.CreateAttachment(fs, "test.txt"));
                        }
                    }
                }
                e.AddData(info, msg);
