        static void Main(string[] args)
        {
            string[] parsedLine;
            string temp;
            String path = @"C:\Users\jhochbau\documents\visual studio 2015\Projects\CsvReader\CsvReader\Position_2016_02_25.0415.csv";
            //var accounts = new Dictionary<string, Positions>();
            //Adding lines read into a string[];
            string[] lines = System.IO.File.ReadAllLines(path);
            string prevControl = string.Empty;
            string currControl = string.Empty;
            int vSettleMMSum = 0;
            int vOpenSum = 0;
            int vBuySum = 0;
            int vSellSum = 0;
            foreach (string line in lines)
            {
                parsedLine = line.Split(',');
                prevControl = currControl;
                currControl = parsedLine[0];
                //need loop here to add these sums and break when vControl changes accounts.
                vSettleMMSum += int.Parse(parsedLine[10]);
                vOpenSum += int.Parse(parsedLine[6]);
                vBuySum += int.Parse(parsedLine[7]);
                vSellSum += int.Parse(parsedLine[8]);
                if (!string.IsNullOrWhiteSpace(prevControl) && !string.Equals(prevControl, currControl))
                {
                    //After each Break need to print out Account name and sums from above.
                    // Do printing here as part of the loop, at the very end of the loop code block.
                    // After printing, reset your values.
                    vSettleMMSum = 0;
                    vOpenSum = 0;
                    vBuySum = 0;
                    vSellSum = 0;
                }
            }
        }
