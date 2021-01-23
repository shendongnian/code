    class Program
    {
        static void Main(string[] args)
        {
            string someString = "1234567";
            string someOtherString = "1287631";
            string anotherString = "123A6F2";
    
            Console.WriteLine(IsValidString(someString));
            Console.WriteLine(IsValidString(someOtherString));
            Console.WriteLine(IsValidString(anotherString));
    
            Console.ReadLine();
        }
    
        public static bool IsValidString(string str)
        {
            bool isValid = true;
    
            char[] splitString = str.ToCharArray(); //get an array of each character
    
            for (int i = 0; i < splitString.Length; i++)
            {
                try
                {
                    double number = Char.GetNumericValue(splitString[i]); //try to convert the character to a double (GetNumericValue returns a double)
    
                    if (number < 0 || number > 7) //we get here if the character is an int, then we check for 0-7
                    {
                        isValid = false; //if the character is invalid, we're done.
                        break;
                    }
                }
                catch (Exception) //this will hit if we try to convert a non-integer character.
                {
    
                    isValid = false;
                    break;
                }                
            }
    
            return isValid;
        }
    }
