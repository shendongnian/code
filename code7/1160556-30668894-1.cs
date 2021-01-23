        public string Union(string one, string two)
        {
            if (one == null || two == null)
                return null;
            int idxOne = -1;
            int j = one.Length - 1;
            for (int i = two.Length - 1; i >= 0; i--)
            {
                if (two[i] == one[j])    // if the current index of string 2 matches the last character of string one, start counting
                {
                    j--;
                    idxOne = j;
                }
                else if (i > 0)
                {
                    j = one.Length - 1;   // throw away results if match stopped  matching half-way in.
                    idxOne = -1;
                }
            }
            if (idxOne != -1)
            {
                return one.Substring(0, idxOne + 1) + two;
            }
            
            return one + two;
        }
