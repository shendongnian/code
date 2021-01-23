    var stringToCheck = "192.168.1.1";
    var countDots = stringToCheck.Split('.').Length - 1;
    if (countDots==3)
    {
        IPAddress validIpAddress;
        if (IPAddress.TryParse(stringToCheck, out validIpAddress))
        {
            //Valid IP, with validIpAddress containing the IP
            Console.WriteLine("Valid IP");
        }
        else
        {
            //Invalid IP
            Console.WriteLine("Invalid IP");
        }
    }
    else
    {
        // Invalid as no "." in string, not even worth checking
        Console.WriteLine("Invalid IP not correct number Dots");
    }
