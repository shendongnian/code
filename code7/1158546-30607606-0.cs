        char[] splitter1 = new char[] { '|' };
        char[] splitterComma = new char[] { ',' };
        public List<string> AdvMultiKeySearch(string key)
        {
            List<string> strings = new List<string>();
            string[] commaSplit = key.Split(splitterComma);
            string[] leftSideSplit = commaSplit[0].Split(splitter1);
            string[] rightSideSplit = commaSplit[1].Split(splitter1);
            for (int l = 0; l < leftSideSplit.Length; l++)
            {
                for (int r = 0; r < rightSideSplit.Length; r++)
                {
                    strings.Add(leftSideSplit[l] + "," + rightSideSplit[r]);
                }
            }
            return strings;
        }
