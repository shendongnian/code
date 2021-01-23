     Console.Write("Search for model:");
     string inputSearch = Console.ReadLine();
     bool carFound = false;
     for (int i = 0; i < myList.Count; i++)
       {
         if (myList[i].Model == inputSearch)
            {
               Console.WriteLine("Model: " + myList[i].Model);
               carFound = true;
            }
       }
      if (!carFound) { Console.WriteLine("None model were found"); }
