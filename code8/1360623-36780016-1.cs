        static void entreeSearch(dailyMenu [,] daysOfMonth)
        {
            Console.WriteLine ("PLease enter the entree you'd like to search for today :)");
            string response = Console.ReadLine ();
            response = response.ToUpper ();
              
            for (int column = 0; column < daysOfMonth.GetLength(0); column++) 
            {
                for (int row = 0; row < daysOfMonth.GetLength(1); row++) 
                {
                    dailyMenu dailyMenuAtThisRowAndColumn = daysOfMonth[column, row];
                    if (dailyMenuAtThisRowAndColumn.Entree.ToUpper() == response)
                    {
                         Console.WriteLine($"Entree {response} was found on day {daysOfMonth[column, row].Day}");
                    }
                }
            }
