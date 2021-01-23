            var allLines = File.ReadAllLines(@"C:\kosalaw\myfile.csv"); //read all lines from the csv file
            MyColumns[] AllColumns = new MyColumns[allLines.Count() -1]; //create an array of MyColumns class
            var colHeaders = allLines[0].Split(new[] {'","'}).ToList(); // Identify columns headers
            for (int index = 1; index < allLines.Length; index++)//loop through the lines. We skip first line as it is the column header
            {
                var line = allLines[index];
                var lineColumns = line.Split(new[] {'","'}); //split each line in to columns
                AllColumns[index - 1] = new MyColumns //now use column header to identify the exact column.
                {
                    K = lineColumns[colHeaders.IndexOf("K")],
                    Mg = lineColumns[colHeaders.IndexOf("Mg")],
                    Mn = lineColumns[colHeaders.IndexOf("Mn")],
                    Na = lineColumns[colHeaders.IndexOf("Na")]
                };
            }
