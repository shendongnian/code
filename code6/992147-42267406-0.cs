            try
            {
                if (ModelState.IsValid)
                {
                    var senderemail = new MailAddress("xxxxx@gmail.com", "Demo Mail");
                    var receiveremail = new MailAddress(receiverEmail, "Receiver");
                    var password = "xxxxx";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderemail.Address, password)
                    };
                    using (var mess = new MailMessage(senderemail, receiveremail)
                    {
                        Subject = subject,
                        Body = body
                    }
                    )
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch(Exception)
            {
                ViewBag.Error = "There is some thing went Wrong";
            }
            return View();
        }
}
