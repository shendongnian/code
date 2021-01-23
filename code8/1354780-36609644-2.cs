    public static void F()
    {
      var rnd1 = new Random();
      var rnd2 = new Random();
      Action a1 = () => G(rnd1.Next());
      Action a2 = () => G(rnd2.Next() + rnd1.Next());
    }
    
    private static void G(int i)
    {
    }
