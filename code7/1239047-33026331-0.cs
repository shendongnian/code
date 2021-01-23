    class Program
    {
        static void Main(string[] args)
        {
        #region Catch5IntegerInArrayOfInt[5]
            // The solution to catching five integers in an array of int[5] 
            // is to use nullable integers.
            // Keeping a counter when entering an integer to the array does not appeal to me.
            // With normal integers I cannot catch 0 as one of the numbers
            // because all ints are initialized with 0
            Console.WriteLine("Please enter five unique numbers consecutively.");
            var fiveNumbers = new int?[5];          // do it using an array just the same (as collections were not part of the lectures so far)
            for (int i = 0; i < fiveNumbers.Length; i++)
            {
                Console.WriteLine("Please enter your {0} number:", (Countables)i);
                CatchUsersNumbers(fiveNumbers, i);
            }
            DisplayResult(fiveNumbers);
            Console.WriteLine("\n");
        }
        #endregion
        #region HelperMethods
        private static void CatchUsersNumbers(int?[] fiveNumbers, int i)
        {
            while (true)
            {
                userInput = Console.ReadLine().Trim();
                if (CheckWhetherInteger(userInput) && CheckUniqueness(fiveNumbers, myInteger))
                {
                    fiveNumbers[i] = myInteger;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You did not enter a unique integer number, try again...");
                }
             }
        }
        private static bool CheckWhetherInteger(string userInput)
        {
                bool result = Int32.TryParse(userInput, out myInteger);
                if (result == false)
                {
                    Console.Clear();
                    Console.WriteLine("You did not enter an integer.");
                }
                return result;
        }
        private static bool CheckUniqueness(int?[] fiveNumbers, int userInput)
        {
            for (int i = 0; i < fiveNumbers.Length; i++)
            {
                if (fiveNumbers[i] == userInput)
                {
                   return false;
                }
            }
            return true;
        }
        private static void DisplayResult(int?[] fiveNumbers)
        {
            Console.Clear();
            Array.Sort(fiveNumbers);
            Console.WriteLine("These are the five interger numbers you entered \nand that were stored in the array:\n");
            for (int i = 0; i < fiveNumbers.Length; i++)
            {
                if (i != fiveNumbers.Length - 1)
                    Console.Write(fiveNumbers[i] + ", ");
                else
                    Console.Write(fiveNumbers[i]);
            }
        }
        #endregion
        #region Class Variables
        private static int myInteger = 0;
        private static string userInput;
        private enum Countables
        {
            first = 0,
            second,
            third,
            fourth,
            fifth
        }
        #endregion
    }
