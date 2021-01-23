            int lineIndex = 1;
            foreach (string line in lines.Skip(1))
            {
                string[] cells = line.Trim()
                    .Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int counter = 0; counter < cols.Length; counter++)
                {
                    string cellValue = "N/A";
                    if (counter < cells.Length)
                        cellValue = cells[counter];
                    Console.WriteLine(
                        "values at row {0} column {1} are {2} : {3}",
                        lineIndex,
                        counter,
                        cols[counter],
                        cellValue);
                }
                lineIndex++;
            }
            Console.ReadKey(); //Stop the window from closing.
