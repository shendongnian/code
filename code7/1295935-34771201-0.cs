      var wqat = 1.1;
      var rat = .2;
      var eat = .8;
      var baat = 1.2;
      var baat2 = 1.8;
    
      // Add's are hard to read
      List<double> theOneList = new List<double>() {
        wqat, rat, eat, baat, baat2 
      };
    
      // Inplace sorting
      theOneList.Sort((x, y) => -x.CompareTo(y));
    
      // Or (worse) Linq
      // theOneList = theOneList.OrderByDescending(z => z).ToList();
    
      List<double> test = new List<double>(); 
      // No magic numbers (i.e. 4) - no out of range exceptions
      for (int i = 0; i < theOneList.Count - 1; ++i)
        test[i].Add(theOneList[i] - theOneList[i + 1]);
    
      // Output
      Console.Write(String.Join(Environment.NewLine, test)); 
