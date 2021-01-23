    private void IsValidInput(string input)
    {
        if(input.Length < 10 || input.Length)
        {
            throw new ArgumentException("Wrong length");
        }
    }
