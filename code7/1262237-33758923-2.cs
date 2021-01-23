        public static void Main()
        {
            var query = "select * from hmAdjusted order by [hmAdjusted] desc;";
            var result = MyQueryFormatter(query);
            Console.WriteLine(result);
        }
    
        public static string MyQueryFormatter(string query)
        {
            var beforeWhatAddNewLine = new string[] { "from", "order" };
            var temp = query.Split(' ');
            var tempLength = temp.Count();
            var result = new StringBuilder();
            for (int i = 0; i < tempLength; i++)
            {
                if (beforeWhatAddNewLine.Contains(temp[i]))
                {
                    result.Append(Environment.NewLine);
                }
                else if (i != 0)
                {
                    result.Append(" ");
                }
                result.Append(temp[i]);
            }
            return result.ToString();
        }
