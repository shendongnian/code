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
     // A as well as N are obtained
     for (j = 0; j < N; j++) 
       if A[j] % 2 != 0
         CUL++;
       else  
         cL++;
  
     if (cL > CUL)
       Console.WriteLine("READY FOR BATTLE");
     else
       Console.WriteLine("NOT READY");
