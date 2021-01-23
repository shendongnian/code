    // List holding all the country data
            private List<country> countryList;
    
            /// <summary>
            /// Handle the button click
            /// </summary>
            /// <param name="sender">See MSDN</param>
            /// <param name="e">See MSDN</param>
            private void button1_Click(object sender, EventArgs e)
            {
                // Initalize a list of country data
                this.countryList = new List<country>();
    
                // Set the display text to the display property of the country class
                this.listBox1.DisplayMember = "Display";
    
                // Set the value of the list box item to the current country
                this.listBox1.ValueMember = "Country";
    
                // Populate the data
                this.PopulateData();
                
                // Set the list box datasource
                this.listBox1.DataSource = this.countryList;
            }
    
            /// <summary>
            /// Gets the country data from the csv file
            /// </summary>
            private void PopulateData()
            {
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
    
                        this.countryList.Add(fileCountry);
                    }
                }
    
                // The process is done show the data
                foreach (country country in this.countryList)
                {
                    Console.WriteLine(country.Display);
                }
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
    
                /// <summary>
                /// Formats the display string for the country 
                /// </summary>
                public string Display
                {
                    get
                    {
                        return string.Format("Country = {0}, GDP = {1}", this.Country, this.GDP);
                    }
                }
            }
