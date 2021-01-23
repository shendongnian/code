        public override string GetOutputCacheProviderName(HttpContext context)
        {
            bool isInSession = true; // Determine here.
            if (isInSession)
            {
                return "CustomProvider";
            }
            // Or by page:
            if (context.Request.Path.EndsWith("MyPage.aspx"))
            {
                return "SomeOtherProvider";
            }
            return base.GetOutputCacheProviderName(context);
        }
