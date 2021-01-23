    string o = Console.ReadLine();
        
    string finalType = "String";
    if (!string.IsNullOrEmpty(o)){
      // Check integer before Decimal
      int tryInt;
      decimal tryDec;
      if (Int32.TryParse(o, out tryInt)){
        finalType = "Integer";
      }
      else if (Decimal.TryParse(o, out tryDec)){
        finalType = "Decimal";
      }    
    }
    
    Console.WriteLine(finalType);
