        static string GetFirstMatch(String uA, String[] a)
        {
            int startMatchIndex = -1;
            string firstMatch = "";
            foreach (string s in a)
            {
                int index = uA.ToLower().IndexOf(s.ToLower());
                if (index == -1)
                    continue;
                else if (startMatchIndex == -1)
                {
                    startMatchIndex = index;
                    firstMatch = s;
                }
                else if (startMatchIndex > index)
                {
                    startMatchIndex = index;
                    firstMatch = s;
                }
            }
            return firstMatch;
        }
