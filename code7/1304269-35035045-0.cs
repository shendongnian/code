    static Random rnd = new Random();   // declaring rnd as static
    public static int openIt(int casse)
    {
       Int32 skin = 0;
       if (casse==1)
       {
          skin = rnd.Next(1, 3);
       }
       return skin;
    }
