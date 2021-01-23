    for (int i = 1; i <= numberOfStudents.Length; i++) { 
      // The i variable is starting on 1, loops til the index is greater than 5 (I.E., 6)
      Console.Write ($"Enter student {i}'s current grade: ");
      numberOfStudents [i] = Convert.ToInt16 (Console.ReadLine ());
      // On last fetch the variable i is 6, trying to fetch from array where last index is 5
      // will make the array throw an exception.
    }
  
