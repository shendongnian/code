    List<List<string>> group = new List<List<string>> { A, B, C, D, E };
    Random rnd = new Random();
    int count = 3; //for triplets
    List<string> result = new List<string>(count);
    for (int i = 0; i < count; i++)
    {
       List<string> row = group[rnd.Next(group.Count)];
    
       if (row == B) group.Remove(C);
       else if (row == C) group.Remove(B);
       result.Add(row[rnd.Next(row.Count)]);
    }
    foreach (string item in result)
    {
         Console.Write(item);
    }
    Console.WriteLine();
