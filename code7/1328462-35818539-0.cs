    public static int? Input(string s)
    {
        int parsed;
        bool Converted = int.TryParse(s, out parsed);
        if (Converted)      // Converted = true
        {
            return null;                
        }
        else                //converted = false
        {
            Console.Clear();
            Console.WriteLine("\n{0}: Is not a number.\n\nPress ENTER to return", s);
            Console.ReadLine();
            return parsed;
        }
    }      
    Console.WriteLine("What alternative?");   
    int? result = Try.Input(Console.ReadLine()); 
    if(result == null)
    {
        return;
    }
    // otherwise, do something with result.Value
