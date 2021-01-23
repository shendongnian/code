            // Create a few files to use in a test
            string TextFile1 = 
                "Element1|Element2|Element4|Element5| " +
                "00000001|00000002|00000004|00000005| " +
                "00000011|00000012|00000014|00000015| " +
                "00000021|00000022|00000024|00000025| " +
                "00000031|00000032|00000034|00000035|";
            string TextFile2 =
                "Element2|Element3|Element4|Element5| " +
                "00000002|00000003|00000004|00000005| " +
                "00000012|00000013|00000014|00000015| " +
                "00000022|00000023|00000024|00000025|";
            string TextFile3 =
                "Element1|Element3|Element4|Element6| " +
                "00000001|00000003|00000004|00000006| " +
                "00000011|00000013|00000014|00000016| " +
                "00000021|00000023|00000024|00000026| " +
                "00000031|00000033|00000034|00000036| " +
                "00000041|00000042|00000044|00000045|";
            
            File.WriteAllText("File1.txt", TextFile1);
            File.WriteAllText("File2.txt", TextFile2);
            File.WriteAllText("File3.txt", TextFile3);
            // Read the files into our class
            Elements elements = new Elements();
            elements.AddFromFile("File1.txt");
            elements.AddFromFile("File2.txt");
            elements.AddFromFile("File3.txt");
            // Build the result
            StringBuilder sb = new StringBuilder();
            
            // First build headers
            foreach (string header in elements.ColumnHeaders)
            {
                sb.Append(header);
                sb.Append("|");
            }
            sb.Append(Environment.NewLine);
            // Next add every row
            foreach (Dictionary<string, string> row in elements.Rows.Values)
            {
                foreach (string header in elements.ColumnHeaders)
                {
                    if (row.ContainsKey(header))
                    {
                        sb.Append(row[header]);
                    }
                    else
                    {
                        sb.Append("________");
                    }
                    sb.Append("|");
                }
                sb.Append(Environment.NewLine);
            }
            // Finally save the result into a file
            File.WriteAllText("Result.txt", sb.ToString());
