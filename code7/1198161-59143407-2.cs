      public static string EmailStarString(string email)
        {          
            string[] parts = email.Split('@');
            string star = string.Empty;
            string firstCharEmailName = parts[0].First().ToString();
            string lastCharEmailName = parts[0].Last().ToString();
            for (int i = 0; i < parts[0].Length - 2; i++)
            {
                star += "*";
            }
            return firstCharEmailName + star + lastCharEmailName + "@" + parts[1];
        }
