    static void Main(string[] args)
            {
                string data = "345, \"test ,,,,,, ,,,,, ,,,,\", 89";
    
                string[] quoteValues = GetValueInQuote(data);
    
                string[] result = data.Split(quoteValues, StringSplitOptions.RemoveEmptyEntries);
    
    
                result = string.Join(string.Empty, result).Replace(" ", string.Empty).Split(new char[1]{','}, StringSplitOptions.RemoveEmptyEntries);
    
                result = result.Concat(quoteValues).ToArray();
    
            }
    
            static string[] GetValueInQuote(string data)
            {
                int quoteCount = data.Where(c => c == '\"').Count();
    
    
            
                if (quoteCount % 2 == 1)
                    throw new Exception("an odd number of quotes");
    
    
                string[] result = new string[quoteCount / 2];
    
               
    
                for (int i = 0; i < result.Length; i++)
                {
                    int first = data.IndexOf('\"');
    
                    int second = data.IndexOf('\"', first + 1);
    
    
                   result[i] = data.Substring(first, second - first + 1);
                }
    
                return result;
    
            }
