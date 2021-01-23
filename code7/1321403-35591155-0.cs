        private List<List<string>> parseData(string data)
        {
            List<List<string>> allValues = new List<List<string>>();
            List<string> currentValues = null;
            // Assume that each line has only one entry
            foreach (var line in data.Split(new [] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries))
            {
                if (line == "#START#")
                {
                    currentValues = new List<string>();
                }
                else if (line == "#END#")
                {
                    allValues.Add(currentValues);
                }
                else
                {
                    currentValues.Add(line);
                }
            }
            return allValues;
        }
