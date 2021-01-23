        string mechanism = "HMACSHA256";
        if (mechanism.StartsWith("HMAC"))
        {
            Console.WriteLine("good");
        }
        else
        {
            Console.WriteLine("bad");
        }
        Console.ReadLine();
