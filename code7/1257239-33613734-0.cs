    //string input = "2*5+7/5-424)";
    Regex getNumbers = new Regex(@"\b(\d)+\b");
    
    var matchColl = getNumbers.Matches(input);
    
    double[] num = new double[matchColl.Count];
    int c = 0;
    
    foreach (Match number in matchColl)
        num[c++] = Convert.ToDouble(number.Value);
