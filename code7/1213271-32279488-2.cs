    public static class ASCIINumberHelper
    {
        // Get an ASCII art representation of a number.
        public static string[] GetASCIIRepresentationForNumber(int number)
        {
            switch (number)
            {
                case 1:
                    return new[]
                    {
                        "|",
                        "|",
                        "|",
                        "|"
                    };
                case 2:
                    return new[]
                    {
                        "---",
                        " _|",
                        "|  ",
                        "---"
                    };
                case 3:
                    return new[]
                    {
                        "---",
                        " / ",
                       @" \ ",
                        "-- "
                    };
                case 4:
                    return new[]
                    {
                        "|  |",
                        "|__|",
                        "   |",
                        "   |"
                    };
                case 5:
                    return new[]
                    {
                        "-----",
                        "|___ ",
                        "    |",
                        "____|"
                    };
                default:
                    return null;
            }
        }
        // See if two numbers represented as ASCII art are equal.
        public static bool ASCIIRepresentationMatch(string[] number1, string[] number2)
        {
            // Return false if the any of the two numbers is null
            // or their lenght is different.
            // if (number1 == null || number2 == null)
            //     return false;
            // if (number1.Length != number2.Length)
            //     return false;
            if (number1?.Length != number2?.Length)
                return false;
            try
            {
                for (int n = 0; n < number1.Length; ++n)
                {
                    if (number1[n].CompareTo(number2[n]) != 0)
                        return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                return false;
            }
            
            return true;
        }
    }
