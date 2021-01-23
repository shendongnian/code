    Int32[] data = new Int32[] {10, -5, 100, Int32.MinValue};
    PrintDataWithoutLength(data, Int32.MinValue);   
    PrintDataWithoutLength<T>(T[] data, T terminator)
    {
         for(Int32 i = 0; !data[i].Equals(terminator) ; i++)
         {
             Console.WriteLine(data[i]);
         }
    }
     
