    private void Test()
        {
            string[] samples = new[] {"nnn", "shhhh", "has", "s", "ash"};
            string chars = "ash";
            var matches = samples.Where(x => IsMatch(x, chars));
        }
        private bool IsMatch(string sample, string matchChars)
        {
            if (sample.Length != matchChars.Length)
                return false;
            sample = matchChars.Aggregate(sample, (current, c) => current.Replace(c, ' '));
            return sample.Trim().Length == 0;
        }
