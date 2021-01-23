            List<Dictionary<string, string>> aLines = new List<Dictionary<string, string>>();
            var aFile = File.ReadAllLines(filename);
            var aColumns = aFile.First().Split('\t');
            aFile.Skip(1).ToList().ForEach(line =>
            {
                var aSplitLine = line.Split('\t');
                Dictionary<string, string> aDictionary = new Dictionary<string, string>();
                for (int i = 0; i < aSplitLine.Length; i++)
                {
                    aDictionary.Add(aColumns[i], aSplitLine[i]);
                }
                aLines.Add(aDictionary);
            });
            int row = 0;
            string fieldValueExample = aLines[row]["field_Value"];
