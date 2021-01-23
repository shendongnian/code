    public static IEnumerable<string> SplitByLine(this string text)
    {
       return text.Split('\n');
    }
    
    public  static IEnumerable<string[]> KeyValuesSplitted(this IEnumerable<string> lines)
    {
       return lines.Select(line => line.Split(':'));
    }
    
    public static IEnumerable<IGrouping<string[]>> GroupyByKey(this IEnumerable<string[]> keyValuesSplitted)
    {
       return keyValuesSplitted.GroupBy(line => line.First());
    }
    
    // and so on..
   
