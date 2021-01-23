    string myCsv;
    if (Session["CSVContent"] == null)
    {
       // read csv here into a variable called csv then:
       Session["CSVContent"] = csv;
       myCsv = csv;
    }
    else
    {
        myCsv = (string)Session["CSVContent"];
    }
    
    // Process myCsv
