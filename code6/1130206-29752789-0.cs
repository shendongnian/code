     static void Main(string[] args)
     {
         var input = "testtest";
         var numDigits = 2;
         bool valid = input.Length > 3
                      && input.Length < 11
                      && input.Where(char.IsLetter).Count() > 3
                      && input.Where(char.IsDigit).Count() > numDigits;
     }
