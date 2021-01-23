        public static bool MatchesPath(this IWebContext webContext, System.Text.RegularExpressions.Regex matchPattern)
        {
            string appRelativePath = webContext.CurrentRequestContext.GetAppRelativePath();
            return matchPattern.IsMatch(appRelativePath);
        }
