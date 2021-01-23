    public static void main(string[] args)
    {
        try {
            Console.Write("Enter a number: ");
            value = DoStuff(Console.ReadLine());
        }
        catch(Exception ex) {
            Console.WriteLine("An exception was thrown.  Contents: " + ex.ToString());
        }
    }
