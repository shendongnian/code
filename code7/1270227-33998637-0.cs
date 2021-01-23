    private static IEnumerable<Player> Start() 
    {
        do
        {
            Console.WriteLine("How Many ? (2-4)");
            Console.WriteLine("");
            try
            { 
                var totalString = Console.ReadLine();
                var total = int.Parse(totalString);
                if (total >= 1 && total <= 4)
                {
                    Console.WriteLine("Number of players :" + total);
                    return new Player[total];
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        } while (true)
    }
