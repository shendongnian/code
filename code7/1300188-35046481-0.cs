        public ActionResult Chat()
        {
            ChatSessionHelper.SetChatSessionCookie();
            return View();
        }
