    public MyMethod(object obj)
    {
      var calc = obj as ICalc;
      if (calc != null)
      {
        calc.Calculate();
      }
    }
