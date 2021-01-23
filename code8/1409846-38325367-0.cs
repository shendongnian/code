    public void Test9(double[] numbers)
    {
        // Find the maximum without linq
        double maxNumber = double.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
           if(numbers[i] > maxNumber) 
              maxNumber = numbers[i];
        }
        
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = numbers[i] / maxNumber;
        }
    }
