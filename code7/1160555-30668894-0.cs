        public string Union(string one, string two)
        {
            if (one == null || two == null)
                return null;
            int idxOne = -1;
            int j = one.Length - 1;
            for (int i = two.Length - 1; i >= 0; i--)
            {
                if (two[i] == one[j])
                {
                    j--;
                    idxOne = j;
                }
                else if (i > 0)
                {
                    j = one.Length - 1;
                    idxOne = -1;
                }
            }
            if (idxOne != -1)
            {
                return one.Substring(0, idxOne) + two;
            }
            
            return one + two;
        }
