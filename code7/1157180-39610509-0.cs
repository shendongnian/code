        public static void Main() 
        {
            Console.WriteLine(ValidateString("", '&')); //False
            Console.WriteLine(ValidateString("Foo&", '&')); //False
            Console.WriteLine(ValidateString("&Foo", '&')); //False
            Console.WriteLine(ValidateString("&&&", '&')); //True
            Console.WriteLine(ValidateString("&", '&')); //True
            Console.ReadLine();
        }
    
       static bool ValidateString(string str, char testChar) 
       {
         if (String.IsNullOrEmpty(str))
            return false;
         if (Regex.Matches(str, testChar.ToString()).Count == str.Length)
            return true;
         else
            return false;
       }
