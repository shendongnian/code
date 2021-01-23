    private void IfNotValidInputForPaymentFormThenThrow(string input)
    {
        if(input.Length < 10 || input.Length)
        {
            throw new ArgumentException("Wrong length");
        }
        
        // other conditions of valid input
    }
