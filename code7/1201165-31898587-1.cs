    String inString = Console.ReadLine();
    int i = 0;
    bool parsedNumber = Int32.TryParse(inString, out i);
    if (parsedNumber) {
        //Do Something with your lovely new Int32
    }
