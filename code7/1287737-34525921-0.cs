        var options = string.Format("Choose between colors:{0}1. Black{0}2. Green{0}3. Red{0} 4. Quit", Environment.NewLine);
        var selection = char.MinValue;
        while (!char.IsDigit(selection))
        {
            Console.WriteLine(options);
            selection = Console.ReadKey().KeyChar;
            Console.Clear();
        }
        int choice = int.Parse(selection.ToString());
        switch (choice)
        {
            case 1:
                Console.WriteLine("Black");
                break;
            case 2:
                Console.WriteLine("Green");
                break;
            case 3:
                Console.WriteLine("Red");
                break;
            case 4:
                break;
        }
