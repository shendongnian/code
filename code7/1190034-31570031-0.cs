    class Program
    {
        static void Main(string[] args)
        {
            // Create a new dictionary
            Dictionary<object, string> CountryList = new Dictionary<object, string>();
            const int MAX_LINES_FILE = 50000;
            string[] AllLines = new string[MAX_LINES_FILE];
            int i = 0;
            //reads from bin/DEBUG subdirectory of project directory
            AllLines = File.ReadAllLines(@"C:\Users\Jack\Documents\countries.csv");
            country[] newCountry = new country[30];
    
            foreach (string line in AllLines)
            {
                if (line.StartsWith("Country")) //found first line - headers
                {
                    headers = line.Split(',');
                }
                else
                {
                   string[] columns = line.Split(',');
                          newCountry[i] = new country();
                     newCountry[i].Country=(columns[0]);
                     newCountry[i].GDP=(columns[1]);
                     newCountry[i].Inflation=(columns[2]);
                     newCountry[i].TB =(columns[3]);
                     newCountry[i].HDI =(columns[4]);
                     newCountry[i].TP = (columns[5]);
    
                    CountryList.Add(newCountry[i].Country, newCountry[i].GDP + "," + newCountry[i].Inflation + "," + newCountry[i].TB + "," + newCountry[i].HDI + "," + newCountry[i].TP);
                    i++;
    
                   foreach (KeyValuePair<object, string> country in CountryList)
                    {
                        Console.WriteLine("Country = {0}, GDP = {1}",
                            country.Key, country.Value);
                    }
    
                }
                Console.ReadKey();
            }
        }
    
        public static string[] headers { get; set; }
    }
    
    
    public class country
    {
        public string Country { get; set; }
        public string GDP { get; set; }
        public string Inflation { get; set; }
        public string TB { get; set; }
        public string HDI { get; set; }
        public string TP { get; set; }
    
    }
