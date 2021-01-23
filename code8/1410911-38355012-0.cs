    public static class Helper
    {
        public static bool IsValidDate(string date)
        {
            var regex = @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$";
            if (!string.IsNullOrEmpty(date))
            {
                var match = Regex.Match(date, regex); 
                return match.Success;
            }
            return true;
        }
    }
