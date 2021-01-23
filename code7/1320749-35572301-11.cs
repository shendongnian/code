    if(Rnd == null)
    {
        Rnd = new Random();
    }
    int Min = p; //Can be any number
    int Max = q; //Can be any number
    if(Min > Max) //Assert that Min is lower than Max
    {
        int Temp = Max;
        Max = Min;
        Min = Temp;
    }
    int Divisor = n; //Can be any number
    int NextRandom = Rnd.Next(Min, Max + 1); //Add 1 to Max, because Next always returns one less than the value of Max.
    while(NextRandom % Divisor != 0)
    {
        NextRandom = Rnd.Next(Min, Max + 1); //Add 1 to Max, because Next always returns one less than the value of Max.
    }
