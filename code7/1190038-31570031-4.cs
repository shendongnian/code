           static void Main(string[] args)
        {
            // Initalize the loop iterator
            int i = 0;
            // Initalize a list of country data
            country[] newCountry = new country[30];
            // Initialize a list of countries
            Dictionary<object, string> countryList = new Dictionary<object, string>();
            // Read all the lines from the file
            string[] fileLines = File.ReadAllLines(@"C:\Users\Jack\Documents\countries.csv");
            // For each line in the file
            foreach (string line in fileLines)
            {
                // Check if the line is a header
                if (line.StartsWith("Country"))
                {
                    headers = line.Split(',');
                }
                else
                {
                    // Split the text data
                    string[] columns = line.Split(',');
                    // Initalize a new country
                    newCountry[i] = new country
                    {
                        Country = columns[0],
                        GDP = columns[1],
                        Inflation = columns[2],
                        TB = columns[3],
                        HDI = columns[4],
                        TP = columns[5]
                    };
                    countryList.Add(newCountry[i].Country, string.Format("{0},{1},{2},{3},{4}", newCountry[i].GDP, newCountry[i].Inflation, newCountry[i].TB, newCountry[i].HDI, newCountry[i].TP));
                    i++;
                }
            }
            // The process is done show the data
            foreach (KeyValuePair<object, string> country in countryList)
            {
                Console.WriteLine("Country = {0}, GDP = {1}", country.Key, country.Value);
            }
            // Wait for the user key
            Console.ReadKey();
        }
        public static string[] headers { get; set; }
        public class country
        {
            public string Country { get; set; }
            public string GDP { get; set; }
            public string Inflation { get; set; }
            public string TB { get; set; }
            public string HDI { get; set; }
            public string TP { get; set; }
        }
