    for (int r = 0; r < COUNTER; r++)
    {
         for (int c = 0; c <= r; c++)
              Console.Write(STAR);    
                
         Console.Write("{0}", (r + 1) * 2);
         Console.WriteLine();
    }
