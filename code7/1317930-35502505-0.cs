    const int Length = 5;
    const int LowerBound = 1;
    // Instanstiate a non-zero indexed array. The array is one-dimensional and
    // has size specified by Length and lower bound specified by LowerBound.
    var numbers = Array.CreateInstance(typeof(double), new int[] { Length }, new int[] { LowerBound });
    // Initialize the array.
    for (int i = numbers.GetLowerBound(0); i <= numbers.GetUpperBound(0); i++)
    {
        numbers.SetValue(i, i);
    }
    
    var variable = (Array)LabVIEWExports.Multiply((dynamic)numbers, 2);
