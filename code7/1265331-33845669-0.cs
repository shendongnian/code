        while (line != null)
        {
            line = myReader.ReadLine();
            int number = -1;
            if (line != null)
            {
                if (Int32.TryParse(line, out number))
                {
                    if (number % 2 == 0)
                    {
                        Console.WriteLine(number);
                    }
                }
            }
        }
