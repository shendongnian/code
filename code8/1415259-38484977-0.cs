     List<string> variable1 = new List<string>() { "a1", "b1", "c1" };
     List<string> variable2 = new List<string>() { "b1", "x1", "y1" };
     foreach (string item in variable2)
     {
         var index = variable1.FindIndex(x => x == item);
         if (index != -1)
         {
             variable1[index] = String.Join(",", variable2);
         }
     }
     Console.WriteLine("Outpur is {0}", String.Join(",", variable1));
