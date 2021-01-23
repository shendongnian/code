    const int NumberOfArrays = 10;
    const int NumberOfValuesInEachArray = 30;
    
    // array of arrays (could also use a List)
    var AllBayReplyArrays = new string[NumberOfArrays][];
    
    // create each nested array
    for (var i = 0; i < NumberOfArrays; i++)
    {
        AllBayReplyArrays[i] = new string[NumberOfValuesInEachArray];
    }
    
    // set values in each array
    for (var i = 0; i < NumberOfArrays; i++)
    {
        for (var j = 0; j < NumberOfValuesInEachArray; j++)
        {
            // you can write whatever values you like here, I have added the indices to be able to validate the output
            AllBayReplyArrays[i][j] = String.Format("Test {0}-{1}", i, j);
        }
    }
    
    // check the values:
    Console.WriteLine("The 5th value of the 1st array should be Test 0-4 (for zero based indexes), it is: {0}", AllBayReplyArrays[0][4]);
    Console.Read(); //to pause execution
