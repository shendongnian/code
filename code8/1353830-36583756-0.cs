        public IDictionary<string, string> GetParams(string query)
        {
            // Perform a validation if URL is valid
            var regex = @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$";
            Regex validator = new Regex(regex, RegexOptions.Compiled);
            if (!validator.IsMatch(query))
            {
                return null;
                // or
                // throw new ArgumentException("Invalid Url");
            }
            var parts = query.Split('?')[1].Split('&');
            return parts.Select(part => part.Split(new[] { "=" }, 2, StringSplitOptions.RemoveEmptyEntries))
                    .ToDictionary(
                    pair =>
                    {
                        return pair[0];
                    },
                    pair =>
                    {
                        return pair[1];
                    }
                );
        }
