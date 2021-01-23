    string o = Console.ReadLine();
        
    string finalType = "String";
    if (!string.IsNullOrEmpty(o)){
      int tryInt;
      if (Int.TryParse(o, out tryInt)){
        finalType = "Integer";
      }
      decimal tryDec;
      if (Decimal.TryParse(o, out tryDec)){
        finalType = "Decimal";
      }    
    }
    
    Console.WriteLine(finalType);
