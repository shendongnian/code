    static void Main()
    {
            var a = new BitArray(new bool[]{true, false,true});
            var b = new BitArray(new bool[]{false, false,true});
            int result = 0;
            int size = Math.Min( a.Length, b.Length); //or a.Length or 200000
            for (int i = 0; i < size ; i++)
            {
               if (a[i] == true && b[i] == true )
               {
                  result++;
               }
            }
            Console.WriteLine("{0}",result);
    }
