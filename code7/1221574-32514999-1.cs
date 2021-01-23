    int input = 3;
    int retVal = 0;
    int summation = 0;  //<=Chnaged from input * input
    for (int i = 1; i <= input; i++)  //<=Changed from 0 to 1
    {
        retVal += i;
        summation +=  i * i;  //<= changed from i
    }
    Console.WriteLine(retVal);
    Console.WriteLine(summation);
