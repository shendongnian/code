    public double? compute1(double n1, double n2, string opr)
    {
       if (opr == "-")
       {
          return (n1 - n2);
       }
       else if (opr == "+")
       {
          return (n1 + n2);
       }
       return null;  // fallback
    }
