        public static DeveloperDetails GetValue(string key)
        {
            DeveloperDetails dd;
            if ( details.TryGetValue(key, out dd) )
            {
                return dd;
            }
            else
            {
                return null;
            }
        }
