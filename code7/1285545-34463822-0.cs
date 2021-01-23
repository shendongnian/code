    class Lendet
    {
         public int Nota { get; private set; }
         public Lendet(int nota)
         {
              this.Nota = nota;
              LendetHistory.Add(this);
         }
    }
    
    static class LendetHistory
    {
         private static List<Lendet> lendets = new List<Lendet>();
         public static float Average()
         {
              if(lendets.Count < 1)
                      return 0;
    
              return lendets.Select(s => s.Nota).Average();
         }
         public static void Add(Lendet lendet)
         {
              lendets.Add(lendet);
         }
    }
