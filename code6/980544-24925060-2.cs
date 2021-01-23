        [HttpPost]
        public ActionResult PostData(object data)
        {
            //1. Save your post data here...
            MailMessage myMessage = new MailMessage();
            //2. Play with your message object here...
            SmtpClient myClient = new SmtpClient("your.smtp.com", 587);
            myClient.SendAsync(myMessage, "myToken");
            return View();
        }
