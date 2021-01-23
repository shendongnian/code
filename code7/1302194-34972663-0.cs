    bool keepPrompting = true;
    while(keepPrompting) {
         Console.WriteLine("Enter the options given below 1.Add students\n 2.View all details\n 3.Sorting\n 4.Exit\n");
        int input = Convert.ToInt16(Console.ReadLine());
        // The case statement on input goes here
         Console.WriteLine("Are you sure you want to exit");
         Console.WriteLine("Y for Yes and 1 for No");
         var y = (char)Console.Read();
         if (y != "y") 
             keepPrompting = false;
    }
    Console.WriteLine("thank you");
