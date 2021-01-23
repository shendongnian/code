    string[,] testString = new string[100, 32766]; //Replace this with your Initialisation / existing string
    var arrayRank = (int)Math.Round((double) 100000 / 32767, 0);
    var arrayIndex = (int)Math.Round((double)100000 % 32767, 0);
    //Test this works.
    //testString[arrayRank, arrayIndex] = "test"; - Test to see that the array range is assignable.
    var result = testString[arrayRank, arrayIndex]; //Test value is what we expect
