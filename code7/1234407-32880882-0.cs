      string tab = "\t";
      string space = new string(' ', 8);
      StringBuilder str = new StringBuilder();
      str.AppendLine(tab + "A");
      str.AppendLine(space + "B");
      string outPut = str.ToString(); // will give two lines of equal length
