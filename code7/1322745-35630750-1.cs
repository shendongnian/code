    int i = 1;
    while(numbers.Count < 10) 
    {
         Console.Write("|Write number " + i + ": ");
         int number = int.Parse(Console.ReadLine());
         if(!numbers.Add(number))
         {
             Console.WriteLine("The number already exists, try again.");
         }
         else 
         {  
             i++;
         }
    }
