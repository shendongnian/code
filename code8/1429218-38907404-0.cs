    void Main()
    {
      string day = "monday";
      if (StringIsDayOfWeek(day))
        Console.WriteLine("is day of week");
      else
        Console.WriteLine("is not day of week");
      
      string s = "";
      if (WhitespaceOnly(s))
        Console.WriteLine("whitespace");
      else
        Console.WriteLine("no whitespace");
    }
    
    bool StringIsDayOfWeek (string day)    
    {    
      return Enum.GetNames(typeof(DayOfWeek)).Contains(day,     StringComparer.OrdinalIgnoreCase);
    }
    
    bool WhitespaceOnly(string s)
    {
      return s!=null && string.IsNullOrWhiteSpace(s);
    }
