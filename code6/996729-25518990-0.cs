        using (ImapClient ic = new ImapClient(imapAddr, myEmailID, myPasswd, ImapClient.AuthMethods.Login, portNo, secureConn))
            {
                ic.SelectMailbox("INBOX");
                bool headersOnly = false;
                Lazy<MailMessage>[] messages = ic.SearchMessages(SearchCondition.Unseen(), headersOnly);
                foreach (Lazy<MailMessage> message in messages)
                {
                    MailMessage m = message.Value;
                    string sender = m.From.Address;
                    string subject = m.Subject;
                    string content = m.Body;
                    if (subject.Equals("QA3 - Purchase Order #3503-197"))//Change string accordingly. 
                        isEmailFound = true;
                    break;
                }
            }
            Assert.IsTrue(isEmailFound, "Order email was not generated");
        }
