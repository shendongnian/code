    static void Main(string[] args)
    {
      float wMyFloat = 1.5f;
      for(int i = 0; i < 100; i++)
      {
        wMyFloat += 0.1f;
      }
      Console.WriteLine(wMyFloat.ToString());
      Console.ReadLine();
    }
