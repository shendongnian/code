    public int nbOccurrences(int[] base1, int n)
    {
       int count = 0;
       foreach (int i in base1)
       {
          if (n == 32)
          {
             count++;
          }
       }
       return count;
    }
    static void Main(string[] args)
    {
        int chiffrebase = 32;
        int[] test123 = new int[] { 12, 32, 33, 64, 75, 46, 42, 32 };
        int occurrences = nbOccurrences(test123, chiffrebase, occurrence);
        Console.WriteLine(occurrences);
    }
