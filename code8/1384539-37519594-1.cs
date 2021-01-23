    ArrayList aryList=new ArrayList();
    aryList.Add(Sample);
    aryList.Add(Test);
    //to store the array list to the session
    Session["AryList"] = aryList;
    //or if you have a class file then
    HttpContext.Current.Session["AryList"] = aryList;
    //to get the values from the session
    ArrayList aryList= (ArrayList)Session["AryList"];
