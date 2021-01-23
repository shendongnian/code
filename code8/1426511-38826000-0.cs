      public void mail(string FromEmail, string FromPass, string To, string Tocc, string Tobcc, string subject, string message, string smtpadd, int portnum)
            {
                try
                {
                    System.Net.Mail.SmtpClient st = new System.Net.Mail.SmtpClient(smtpadd);
                    System.Net.Mail.MailMessage mst = new System.Net.Mail.MailMessage();
                    mst.To.Add(To);
                    if (Tocc != "")
                    {
                        mst.CC.Add(Tocc);
                    }
                    if (Tobcc != "")
                    {
                        mst.Bcc.Add(Tobcc);
                    }
                    mst.IsBodyHtml = true;
                    mst.From = new System.Net.Mail.MailAddress(FromEmail);
                    mst.Subject = subject;
                    mst.Body = message;
                    System.Net.NetworkCredential nc = new System.Net.NetworkCredential(FromEmail, FromPass);
                    st.UseDefaultCredentials = true;
                    st.EnableSsl = true;
                    st.Port = portnum;
                    st.Credentials = nc;
    
                    st.Send(mst);
                }
                catch (Exception e)
                {
                }
            }
