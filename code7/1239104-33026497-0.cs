    private static double? ReadLineDouble()
    {
        while(true) {
            string s = Console.ReadLine();
            if (String.IsNullOrWhitespace(s)) {
                return null; // The user wants to abort
            }
            double d;
            if (Double.TryParse(s, out d)) {
                return d;
            }
            Console.WriteLine("Please enter a valid number");
        }
    }
