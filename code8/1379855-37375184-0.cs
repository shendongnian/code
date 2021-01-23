        private string charMatch(string str_a, string str_b) 
        {
            int char_a = str_a.Count();
            int char_b = str_b.Count();
            int runs = 0;
            StringBuilder sb = new StringBuilder();
            if (char_a <= char_b) { runs = char_a; }
            else { runs = char_b; }
            for (int i = 0; i < runs; i++) 
            {
                if (str_a[i] == str_b[i]) 
                {
                    sb.Append(string.Format("Match found at {0} \n", i));
                }
            }
                return sb.ToString();
        }
