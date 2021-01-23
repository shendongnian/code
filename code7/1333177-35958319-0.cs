          do
          {
            cki = Console.ReadKey();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                //here will be the command which reads the enter key and stops the loop
            }
    
           } while (cki.Key != ConsoleKey.Escape);
