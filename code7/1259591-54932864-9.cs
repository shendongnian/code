        //instantiate a Random generator
        Random random = new Random();
        //define three integer ranges
        List<Range<int>> intRanges = new List<Range<int>>();
        intRanges.Add(new Range<int>(0, 10));
        intRanges.Add(new Range<int>(50, 60));
        intRanges.Add(new Range<int>(100, 110));
        //define three double ranges
        List<Range<double>> doubleRanges = new List<Range<double>>();
        doubleRanges.Add(new Range<double>(0, 5.5));
        doubleRanges.Add(new Range<double>(50, 55.5));
        doubleRanges.Add(new Range<double>(100, 105.5));
        //generate a random number between one of above three integer ranges
        //it is shown in the Visual Studio - Output window (Ctrl-W,O)
        Console.WriteLine(random.NextFromRanges(intRanges));
        Console.WriteLine(random.NextDoubleFromRanges(doubleRanges));
