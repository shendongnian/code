    while(counter < 100)
    {
        var tempInput = 0.0D;
        Double.TryParse(Console.ReadLine(), out tempInput);
        if(tempInput == 0.0D)
        {
            // The user did not enter something that can be parsed into a double
            // If you'd like to use that as the signal that the user is finished entering data,
            // just do a break here to exit the loop early
            break;
        }
        inputs.Add(tempInput);
        // This is your limiter, once counter reaches 100 the loop will exit on its own
        counter++;
    }
