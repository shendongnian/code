      List<int> Data = new List<int>();
    
      // Add item after item
      Data.Add(1);
      Data.Add(2);
    
      // Add whole range of items, e.g. an array
      Data.AddRange(new int[] {3, 4, 5});
    
      int v = Data[0];
      Data[0] = v + 10;
    
      Console.Write(String.Join(", ", Data));
