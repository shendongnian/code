    private static bool GetNumberFromConsole()
        {
            bool isValid = false;
            int input = -1;
            while (!isValid)
                if (int.TryParse(Console.ReadLine(), out input))
                    isValid = true;
                else
                    Console.WriteLine("not a number");
            Console.WriteLine("number entered:" + input);
            return isValid;
    }
