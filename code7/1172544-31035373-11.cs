            string filename = @"C:\firstfile.txt";
            //Regex objects to detect every range of spaces between 1-infinite, OR one tab.
            Regex regx = new Regex(@"[\s]+|[\t]", RegexOptions.Compiled);
            //Read all lines of a file, one line per index
            string[] lines = File.ReadAllLines(filename);
            //Create multi-dimensional List array
            List<List<string>> sheet = new List<List<string>>();
            //Split each line in lines by column, and you end up with a multi-dimensional array.
            //Makes it look like an excel sheet. [Row][Column]
            sheet.AddRange(lines.Select(x => new List<string>(regx.Split(x).ToList())));
            //Start from rowIndex = 1, as 0 contains the headers
            for (int rowIndex = 1; rowIndex < sheet.Count; rowIndex++)
            {
                for (int colIndex = 0; colIndex < sheet[rowIndex].Count; colIndex++)
                {
                    Console.WriteLine("values at row {0} column {1} are {2} : {3}",
                        rowIndex,
                        colIndex,
                        sheet[0][colIndex],
                        sheet[rowIndex][colIndex]
                        );
                }
            }
