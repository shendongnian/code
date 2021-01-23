        [HttpPost]
        public ActionResult PostData(object data)
        {
            //...Save your post data here...
            MailMessage myMessage = new MailMessage();
            //...Play with your message object here...
            SmtpClient myClient = new SmtpClient("your.smtp.com", 587);
            bool sentOk = true;
            try
            {
                myClient.Send(myMessage);
            }
            catch
            {
                sentOk = false;
            }
            return RedirectToAction("PostConfirmed", new { confirmEmail = sentOk });
        }
