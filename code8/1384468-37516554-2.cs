    string[] splitResponses = response.Split (delimiter);     // Split string
    int sum=0; 
    foreach(string s in splitResponses)
    {
        var valueInt = int.Parse(s); // convert string to an int.
        sum+= valueInt;   
    }   
    double average = (double)sum/splitResponses.Length;
