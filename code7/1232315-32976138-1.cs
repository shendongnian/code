    [System.Web.Services.WebMethod]
    public static string GetDataReport1()
    {
       //first load the application variable before performing your other work
       DataTable myExistingData = (DataTable)Cache["Report1"];
       //did the Cache expire?
       if (myExistingData == null)
       {
       //if so refresh it
       loadReport1IntoCache();
       //and then assign the variable the contents of the refresh and proceed
       myExistingData = (DataTable)Cache["Report1"];
       }
       //other work here, utilizing the myExistingData variable
    }
