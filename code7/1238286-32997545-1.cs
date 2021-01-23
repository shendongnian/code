    private int GetUserValue(int index)
    {
        var secondValueValid = false;
        int secondValue;
        do
        {
            Console.WriteLine("Please enter the value at index {0}: ", index);
            if(int.TryParse(Console.ReadLine(), out secondValue))
            {
                secondValueValid = true;
            }
            else
            {
                Console.WriteLine("Value entered is not a whole integer, please try again.");
            }
        }
        while(!secondValueValid)
        return secondValue;
    }
