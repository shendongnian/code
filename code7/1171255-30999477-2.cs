    int age;
    string[] messages = new string[] { "How old are you?"
                                     , "Give me an actual answer..."
                                     , "I don't have all day."
                                     };
    int numberOfTries = 0;
    do
    {
        if (numberOfTries >= messages.Length)
        {
            Console.WriteLine(messages[messages.Length - 1]);
        }
        else
        {
            Console.WriteLine(messages[numberOfTries]);
        }
        numberOfTries++;
    }
    while (!int.TryParse(Console.ReadLine(), out age));
    agedetermine();
