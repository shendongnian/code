    string[] names = new string[] {
      "Name", "Class", "Score"};
    
    foreach (string name in names)
      for (char charac = 'A'; charac <= 'C'; ++charac){
        for (int m = 1; m <= 4; ++m)
          dt.Columns.Add(String.Format("{0}_{1}{2}", name, charac, m));
