    public string getMax()
    {
       GRNHDReturn grh = new GRNHDReturn();
       int? max = (from o in context.GRNHDReturns
                      select (int?)o.ReturnId).Max();
       if (max == 0 || max == null)
       {
          max = 1;
          calculatemax = "RN" + max.ToString();
       }
       else
       {
          int? nextmax = max + 1;
          calculatemax = "RN" + nextmax.ToString();
       }
       return calculatemax;
    }
