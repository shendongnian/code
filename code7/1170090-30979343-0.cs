                SqlDataReader dtr = sqlcmd.ExecuteReader();
                while (dtr.Read())
                {
                    if (dtr[2].ToString().Equals(TextBox1.Text))
                    {
                        MailMessage mail = new MailMessage();
                        mail.To.Add(dtr[2].ToString());
                        mail.From = new MailAddress("youremail@hotmail.com");
                        mail.Subject = "Your userId and Password";
                        mail.Body = "Your<br/> UserId:<b>" + dtr[0].ToString() + "</b><br/>" + "Password:<b>" + dtr[1].ToString() + "</b>";
                        
                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.live.com";
                        smtp.Credentials = new System.Net.NetworkCredential("yyyyyyyy@hotmail.com", "xxxxxx");
                        // NetworkCredential.UserName = "";
                        smtp.EnableSsl = true;
                        smtp.Port = 25;
                      
                        //TLS / SSL required = yes;
                        //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        //smtp.EnableSsl = true;
                        //smtp.UseDefaultCredentials = true;
                        //smtp.EnableSsl = true; //Gmail works on Server Secured Layer
                        //try
                        //{
                        //    smtp.Send(mail);
                        //}
                        //catch (Exception ex)
                        //{}
                         smtp.Send(mail);
                        
                       
                       
                       
                            
                       
                       
                        Label1.Text = "check your mailbox for user iD and Password";
                        string javaScript = "<script language=JavaScript>\n" + "alert('User Id and password send to Your mail box');\n" + "</script>";
                        RegisterStartupScript("xyz", javaScript);
                        break;
                    }
                    else
                    {
                        Label1.Text = "Email Id not valid";
                    }
                }
