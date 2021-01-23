    List<int> FindIntegers(string input) 
    {
       Regex regex = new Regex("(\d+)");
       List<int> result = new List<int>();
       foreach (Match match in regex.Matches(input))  
       {
           result.Add(int.Parse(match.Value));
       }
       return result;
    }
