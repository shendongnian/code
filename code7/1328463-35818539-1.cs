    public static bool Input(string s, out int parsed)
    {
        bool Converted = int.TryParse(s, out parsed);
        if (Converted)      // Converted = true
        {
            return false;                
        }
        else                //converted = false
        {
            Console.Clear();
            Console.WriteLine("\n{0}: Is not a number.\n\nPress ENTER to return", s);
            Console.ReadLine();
            return true;
        }
    }       
    Console.WriteLine("What alternative?");   
    int z;
    if(!Try.Input(Console.ReadLine(), out z))
    {
        return;
    }
    // otherwise, do something with z
