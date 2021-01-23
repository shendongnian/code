    public static class ChatSessionHelper
    {
        public static void SetChatSessionCookie()
        {
            var context = HttpContext.Current;
            HttpCookie cookie = context.Request.Cookies.Get("Session") ?? new HttpCookie("Session", GenerateChatSessionId());
            context.Response.Cookies.Add(cookie);
        }
        public static string GetChatSessionId()
        {
            return HttpContext.Current.Request.Cookies.Get("Session")?.Value;
        }
        public static string GenerateChatSessionId()
        {
            return Guid.NewGuid().ToString();
        }
    }
