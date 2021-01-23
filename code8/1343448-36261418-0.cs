      int N = int.Parse(Console.ReadLine());
    
      String line = Console.ReadLine();
    
      int[] A = line
        .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(item => int.Parse(item))
        .ToArray();
    
      // given N differs from actual one
      if (N != A.Length) {
        // Throw an exception or re-assign N
        N = A.Length;
      }
