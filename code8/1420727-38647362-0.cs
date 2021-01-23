    List<double> numbers = new List<double>() { 2.1, 2.2, 4, 4.1, 8, 8.2 };
    List<double> averages = new List<double>();
    while (numbers.Count > 0)
    {
        int numberOfMatches = 1; // The number at numbers[0] is a match
        double sum = numbers[0]; // Add numbers[0] to the sum
        for (int i = 1; i < numbers.Count; i++) // Go through all number except the first
        {
            if (numbers[0] <= numbers[i] && numbers[i] < (int)numbers[0] + 1) // If numbers[i] is withing the x to x + 1 range
            {
                sum += numbers[i]; // Add the new number
                numberOfMatches++; // Increase the number of numbers summerised
                numbers.RemoveAt(i); // Remove the current number since it's already been used
                i--; // Go back one step to not skip a number, since a number was just removed
            }
        }
        numbers.RemoveAt(0); // Remove numbers[0]
        averages.Add(sum / numberOfMatches); // Add the average to averages
    }
