    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Mail;
    namespace ConsoleApplication1
    {
        class Program
        {
        static string msg = "";
        static string password = "password";
        static string to = "number@vtext.com";
        static string from = "myemail@gmail.com";
        static void Main(string[] args)
        {
            Console.WriteLine("Type in your message");
            msg = Console.ReadLine();
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = msg;
            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.Port = 465;
            smtp.Timeout = 30000;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential(from, password);
            smtp.Host = "smtp.gmail.com";
            try
            {
                Console.WriteLine("message sending...");
                smtp.Send(message);
                Console.WriteLine("message sent");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
            }
        }
    }
