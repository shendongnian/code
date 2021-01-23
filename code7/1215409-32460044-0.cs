        static class WebExtensions
        {
            public static void EndSafe(this HttpResponse response)
            {
                response.Flush();
                response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
    
            public static void RedirectSafe(this HttpResponse response, string url)
            {
                response.Redirect(url, false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
