       public static string fehlerrechenzeichen(string rechenzeichen)
        {
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    rechenzeichen = Console.ReadLine();
                    switch (rechenzeichen)
                    {
                        case "+":
                            break;
                        case "-":
                            break;
                        case "*":
                            break;
                        case "/":
                            break;
                        default:
                            throw new FormatException("Geben sie eine gültiges Rechenzeichen ein!");
                    }
                    tryAgain = false;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return rechenzeichen;
        }
