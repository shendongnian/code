    int [] namn = new int [5];
    
    //DONE: namn.Length - no magic numbers (5)
    for (int i = 0; i < namn.Length; i++) // !!! no ";" !!!
    {
       Console.Write("Ange fem namn");
       // put into array
       namn[i] = int.Parse(Console.ReadLine());
    }
    
    // Print the names
    foreach(var item in namn)
      Console.WriteLine(item);
