        string input = "45-78";
        if(input.Contains("-"))
        {
            // the string contains the special character which separates our two number values
            string firstPart = input.Split('-')[0]; // now we have "45" 
            string secondPart = input.Split('-')[1]; // now we have "78"
            int firstNumber;
            bool isFirstPartInt = Int32.TryParse(firstPart, out firstNumber);
            bool isResultValid = true;
            if(isFirstPartInt)
            {
                //check for the range to which the firstNumber should belong
            }
            else isResultValid = false;    
    
            int secondNumber;
            bool isFirstPartInt = Int32.TryParse(secondPart, out secondNumber);
            if(isFirstPartInt)
            {
                //check for the range to which the secondNumber should belong
            }
            else isResultValid = false;    
    
            if(isResultValid)
            {
               // string was in correct format and both the numbers are as expected.
               // proceed with further processing
            } 
        }
    
       else
       {
           // the input string is not in correct format
       }
