    //DONE: "string[]" - Create a STRING vector with five elements... 
    string [] namn = new string [5];
    
    //DONE: namn.Length - no magic numbers (5)
    for (int i = 0; i < namn.Length; i++) // !!! no ";" !!!
    {
       Console.Write("Ange fem namn");
       //DONE: put into array, not to a local variable
       namn[i] = Console.ReadLine();
    }
    
    // Print out the names
    foreach(var item in namn)
      Console.WriteLine(item);
