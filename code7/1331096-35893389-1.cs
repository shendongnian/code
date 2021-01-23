    public static void main(string[] args)
    {
        try {
            int value = 0;
            do {
                try {
                    Console.Write("Enter a non-zero number to stop: ");
                    value = DoStuff(Console.ReadLine());
                }
                catch(ArgumentException ex) {
                    Console.WriteLine("Problem with input, try again.  Exception message was: " + ex.Message);
                    continue; // Or just nothing, will still loop
                }
            } while(value == 0);
        }
        catch(Exception ex) {
            Console.WriteLine("An exception was thrown.  Contents: " + ex.ToString());
        }
    }
