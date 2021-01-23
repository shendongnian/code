    public static bool StartHi(string str)
    {
        bool firstHi;    
        if(string.IsNullOrEmpty(str))
        {
            Console.WriteLine("The string is empty!");
        }
        else
        {
            string strLower = str.ToLower();
            string[] words = strLower.split(' ');
            if ((words.length == 0 && strLower == "hi") || (words[0] == "hi"))
            {
                firstHi = true;
                Console.WriteLine("The string starts with \"hi\"");
            }
            else
            {
                firstHi = false;
                Console.WriteLine("The string doesn't start with \"hi\"");
            }
        }
        Console.ReadLine();
        return firstHi;
    }
