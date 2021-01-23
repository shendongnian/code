    private static void WriteUpdatedBookingDetails(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            WriteUpdatedBookingDetails(text);   //<<<<< here runs the infinite loop
        }
