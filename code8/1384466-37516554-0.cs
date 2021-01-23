    string[] splitResponses = response.Split (delimiter);     // Split string
    int sum; 
    foreach(string s in splitResponses)
    {
        var valueInt = int.Parse(s); // convert string to an int.
        sum+= valueInt;   
    }   
    double average = (double)sum/splitResponses;
