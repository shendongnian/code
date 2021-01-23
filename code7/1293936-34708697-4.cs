    string myCsv;
    if (Application["CSVContent"] == null)
    {
       // read csv here into a variable called csv then:
       Application["CSVContent"] = csv;
       myCsv = csv;
    }
    else
    {
        myCsv = (string)Application["CSVContent"];
    }
    
    // Process myCsv
