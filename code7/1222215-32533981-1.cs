        // Add quote characters as needed.
        List<char> quotes = new List<char> { '\'', '‘', '’' };
        public string CleanName(string name)
        {
            StringBuilder cleanName = new StringBuilder(name);
            foreach (char quote in quotes)
            {
                cleanName = cleanName.Replace(quote, '\'');
            }
            return cleanName.ToString();
        }
        public bool IsMatch(string n0, string n1)
        {
            return String.Compare(CleanName(n0), CleanName(n1)) == 0;
        }
