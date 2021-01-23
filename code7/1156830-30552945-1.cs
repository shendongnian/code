    int sin = 0;
    while (true) {
        String digits = Console.ReadLine();
        if (digits.Length == 9 && Int32.TryParse(digits, out sin)) {
            if (sin >= 100000000) {
                break;
            }
        }
        Console.WriteLine("Error invalid entry");
    }
