    public static Tuple<List<string>, List<string>> GetAllData()
    {
        List<string> CountryName = new List<string>();
        List<string> CountryCode = new List<string>();
        using (var sr = new StreamReader(@"Country.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                int index = line.LastIndexOf(" ");
                CountryName.Add(line.Substring(0, index));
                CountryCode.Add(line.Substring(index + 1));
            }
        }
        return new Tuple<List<string>, List<string>>(CountryName,CountryCode);
    }
