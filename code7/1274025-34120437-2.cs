    private static int GetNumber(string request)
    {
        bool succeeded = false;
        Console.WriteLine(request);
        string reply="";
        while(!succeeded)
        {
            
            reply = Console.ReadLine();
            try
            {
                int.Parse(reply);//Attempt to convert "reply" into an integer.
                succeeded = true;
            }
            catch
            {
                Console.WriteLine(request+" (make it a number)");
            }
        }
        return int.Parse(reply);
    }
