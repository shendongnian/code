    private static bool ValidateString(string input)
        {
            bool retValue = true;
            char[] validChars = { 'a', 'b', 'd' };
            foreach (var character in input)
            {
                //count the number of times the character occurs in the input string
                var characterCount = input.Count(c => c == character);
                //count the number of times the character occurs in the allowed char array
                var allowedCharacterCount = validChars.Count(c => c == character);
                //if the string contains more than the character array allows, immediately fail.
                if (characterCount > allowedCharacterCount)
                {
                    retValue = false;
                    break;
                }
                
            }
            return retValue;
            
        }
