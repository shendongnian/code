    public class HelloWorld
    {
        static public void Main ()
        {
        Console.WriteLine("Enter a number");
        String input = Console.ReadLine();
        int UserNumber = 0;
        if(input != null && input != "")
        {
            UserNumber = int.Parse(input);
        }
        Console.WriteLine("Your number is: " + UserNumber);
        }
    }
