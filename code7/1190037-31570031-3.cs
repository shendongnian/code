    static void Main(string[] args)
    {
        // Initalize a list of country data
        List<country> countryList = new List<country>();
        // Read all the lines from the file
        string[] fileLines = File.ReadAllLines(@"countries.csv");
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
                country fileCountry = new country
                {
                    Country = columns[0],
                    GDP = columns[1],
                    Inflation = columns[2],
                    TB = columns[3],
                    HDI = columns[4],
                    TP = columns[5]
                };
                countryList.Add(fileCountry);
            }
        }
        // The process is done show the data
        foreach (country country in countryList)
        {
            Console.WriteLine("Country = {0}, GDP = {1}", country.Country, country.GDP);
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
