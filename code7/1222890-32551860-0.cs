      static void Main(string[] args)   
      {
          int choice = 0;
          while (choice != 3)
          {
               Console.WriteLine("Main Menu");
               Console.WriteLine("Rent=1");
               Console.WriteLine("Return=2");
               Console.WriteLine("Exit=3)");
               choice = GetUserChoice("What is your choice?", choice);
               if (choice == 1)
               {
                  //when complete all thing in choice 1
                  choice = GetUserChoice("Do you want to start over?(Y=1,N=3)", choice);
               }
               else if(choice == 2)
               {
                   //when complete all thing in choice 2
                   choice = GetUserChoice("Do you want to start over?(Y=1,N=3)", choice);
               }
           }
       }
        
       private static int GetUserChoice(string question, int choice)
       {
           Console.WriteLine(question);
           return  Convert.ToInt32(Console.ReadLine());
       }
