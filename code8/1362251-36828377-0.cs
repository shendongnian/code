    Console.WriteLine("Type in several Integers:");
    string input = System.Console.ReadLine();
    string[] splittedLine = input.Split(' ');
    int max = Int32.MinValue; // initialize the maximum number to the minimum possible values
    int min = Int32.MaxValue;  // initialize the minimum number to the maximum possible value
    foreach(string number in splittedLine)
    {
        int currentNumber = int.Parse(number); // convert the current string element 
                                               // to an integer so we can do comparisons
        if(currentNumber > max)  // Check if it's greater than the last max number
           max = currentNumber;  // if so, the maximum is the current number
        if(currentNumber < min)  // Check if it's lower than the last min number
           min = currentNumber;  // if so, the minium is the current number
    }
    Console.WriteLine(string.Format("Minimum: {0} Maximum: {1}", min, max));
