    public static long Fibon(long num)
    {
      long result ;
      if (num == 1) { return 1; }
      else if (num=2) { return 1; }
      long grandfather = 1 ;
      long father = 1 ;
      for (in i=2;i<=num;i++) 
      {
        result = father + grandFather;
        grandfather = father ;
        father = result ;
      }
      return result ;
    }
