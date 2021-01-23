      List<string> list = new List<string>();
      char[] sep = new char[1];
      sep[0] = ',';
      foreach (string item in lst)
      {
           list.AddRange(item.Split(sep));
      }
      list = list.Distinct().ToList();
