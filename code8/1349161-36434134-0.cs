        public static DeveloperDetails GetValue(string key)
        {
            DeveloperDetails dd = null;
            if ( details.TryGetValue(key, out dd) )
            {
                return dd;
            }
            else
            {
                return null;
            }
        }
