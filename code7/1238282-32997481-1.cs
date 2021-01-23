    private void SumNumbers() 
    {
        int index;
        int num = 0;
        for (index = 1; index <= numOfInput; index++) 
        {
            Console.Write("Please give the value no. " + index + " (whole number):");
            if(Input.ReadIntegerConsole2(out num))
                sum += num;
            else 
                // Decrement the counter to avoid skipping an input
                index--;
        }
    }
