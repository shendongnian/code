        public static string ScrubData(string line)
        {
            string[] words = line.Split('|');
            System.Text.StringBuilder sb = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                sb.Append(GetRandomNumber().ToString());
                if (i + 1 < words.Length)
                    sb.Append("|");
            }
            return sb.ToString();
        }
