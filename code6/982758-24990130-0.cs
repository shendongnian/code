      string test = "foo";
      try {
         Console.WriteLine("{0}", 
                           Convert.ChangeType(test, typeof(Int32)));
      }
      catch (InvalidCastException) {
      }
