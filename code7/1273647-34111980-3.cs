    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Draw(' ', '\u00A9', 20, true);
    }
    
    static void Draw(char sym, char back, int length, bool padding)
    {
        if (length < 5)
        {
            length = 5;
        }
        else if ((length % 2) == 0) // Ensure an odd length using a modulo operation
        {
            length++;
        }
    
        if (padding)
        {
            Console.WriteLine(new string(back, length));
        }
    
        int mid = length / 2;
        int left = mid;
        int right = mid + 1;
    
        do
        {
            Console.Write(new string(back, left));
            Console.Write(new string(sym, right - left));
            Console.Write(new string(back, length - right));
            Console.WriteLine();
    
            left--;
            right++;
        }
        while (left != 0);
    
        if (padding)
        {
            Console.WriteLine(new string(back, length));
        }
    
        Console.WriteLine();
    }
