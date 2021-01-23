    int max = Int32.MinValue;
    for (var i = 0; i < array.Length; i++)
    {
       if (array[i] > max) {
         max = array[i];
       }
    }
    Console.WriteLine(max);
