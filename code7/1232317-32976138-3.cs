    [System.Web.Services.WebMethod]
    public static string GetDataReport1()
    {
       //first load the application variable before performing your other work
       DataTable myCachedReport1Data = (DataTable)Cache["Report1"];
       //did the Cache expire?
       if (myCachedReport1Data == null)
       {
       //if so refresh it
       loadReport1IntoCache();
       //and then assign the variable the contents of the refresh and proceed
       myCachedReport1Data = (DataTable)Cache["Report1"];
       }
       //other work here, utilizing the myCachedReport1Data variable
    }
