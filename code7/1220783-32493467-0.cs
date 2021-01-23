        Console.WriteLine("Enter some numbers: ");
        Console.WriteLine("To finish, press Enter");
        int i=0;
        while ((x = Console.ReadLine()) != "")
        {
            i++;
            t = Convert.ToDouble(x);
            s *= t;
        }
        Console.WriteLine("The result is: {0}", s);
        Console.ReadLine();
