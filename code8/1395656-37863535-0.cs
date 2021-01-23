            List<string> newColumnData = new List<string>() { "D" };
            List<string> lines = File.ReadAllLines(@"C:/CSV/test.csv").ToList();
            //add new column to the header row
            lines[0] += ",Column 4";
            //add new column value for each row.
            for (int i = 1; i < lines.Count; i++)
            {
                int newColumnDataIndex = i - 1;
                if (newColumnDataIndex > newColumnData.Count)
                {
                    throw new InvalidOperationException("Not enough data in newColumnData");
                }
                lines[i] += "," + newColumnData[newColumnDataIndex];
            }
            //write the new content
            File.WriteAllLines(@"C:/CSV/test.csv", lines);
