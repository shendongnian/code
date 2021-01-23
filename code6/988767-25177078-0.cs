    [WebMethod]    
    [XmlInclude(typeof(Class_Name))]
    public bool updatedata(Class_Name ObjectName)
    {
    string name =ObjectName.Name;
    int id = ObjectName.ID;
    int age= ObjectName.Age;
    //Here the code for database storage etc., etc., and return the value...
    return true;
    }
    Client has to create the proxy class and pass the object to this web service to do the functionalities.
