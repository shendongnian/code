    private class Closure
    { 
      public int myVar;
      public int SomeFunction (int var1)
      {
        this.myVar = this.myVar + 1;
        return var1 + this.myVar;
      }
    }
    public static Func<int,int> GetAFunc()
    {
        Closure locals = new Closure();
        locals.myVar = 1;
        Func<int, int> inc = locals.SomeFunction;
        return inc;
    }
