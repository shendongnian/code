    ArrayList aryList=new ArrayList();
    aryList.Add(Sample);
    aryList.Add(Test);
    //to store the array list to the session
    Session["AryList"] = aryList;
    //to get the values from the session
    ArrayList aryList= (ArrayList)Session["AryList"];
