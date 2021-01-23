    public string LookUpValues(string year)
    {
        for(var ii = 0; ii < Year.Length; ii++)
        {
           if(Year[ii] == year)
           {
             return Year[ii] + ", " + Months[ii] + ", " + NumOfCars[ii]
    
           }
        }
    } 
