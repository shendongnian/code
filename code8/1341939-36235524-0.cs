    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Mail;
    using System.Net;
    
    namespace EmailTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                SendMail();
            }
    
            public static void SendMail()
            {
                MailAddress ma_from = new MailAddress("senderEmail@email", "Name");
                MailAddress ma_to = new MailAddress("targetEmail@email", "Name");
                string s_password = "accountPassword";
                string s_subject = "Test";
                string s_body = "This is a Test";
    
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    //change the port to prt 587. This seems to be the standard for Google smtp transmissions.
    				Port = 587,
    				//enable SSL to be true, otherwise it will get kicked back by the Google server.
                    EnableSsl = true,
    				//The following properties need set as well
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(ma_from.Address, s_password)
                };
    
    
                using (MailMessage mail = new MailMessage(ma_from, ma_to)
                {
                    Subject = s_subject,
                    Body = s_body
    
                })
    
                    try
                    {
                        Console.WriteLine("Sending Mail");
                        smtp.Send(mail);
                        Console.WriteLine("Mail Sent");
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                                    ex.ToString());
                        Console.ReadLine();
                    }
    
            }
    
        }
    }
