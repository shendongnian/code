    var Ab = new float[,]
    {
        {1, 4, -2, 104},
        {3, 5, 100, 90},
        {2, -3, 48, 2}
    };
    // Size of float.
    var floatSize = sizeof (float);
    // Number of elements in a row.
    var numRowElements = 4;
    // Temporary array for an intermediate step in the swap operation.
    var temp = new float[numRowElements];
           
    // Copy first row into a temporary array.
    System.Buffer.BlockCopy(Ab, 0, temp, 0, numRowElements*floatSize);
    // Copy second row into the first row.
    System.Buffer.BlockCopy(Ab, numRowElements*floatSize, Ab, 0, numRowElements*floatSize);
    // Copy temporary array into the second row.
    System.Buffer.BlockCopy(temp, 0, Ab, numRowElements*floatSize, numRowElements*floatSize);
