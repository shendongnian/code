        public override string GetOutputCacheProviderName(HttpContext context)
        {
            bool isInSession = true; // Determine if item should be cached or not.
            if (isInSession)
            {
                return "CustomProvider";
            }
            return base.GetOutputCacheProviderName(context);
        }
