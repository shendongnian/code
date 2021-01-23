    StreamReader myFile = new StreamReader(@"path_here");
    const int MAX = 50;
    string inputLine = "";
    // Resistors[] resistor = new Resistors[MAX];             
    int count = 0;
    int resistance = 0;
    while (inputLine != null)
    {
        inputLine = myFile.ReadLine();
        if (inputLine != null && count < MAX)
        {
            int inputInteger = int.Parse(inputLine);
            if (count == 0) { resistance = inputInteger; }
            resistor[count++] = new Resistors(inputInteger, resistance);
        }
    }
