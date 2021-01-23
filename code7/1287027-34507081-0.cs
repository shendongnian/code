    public delegate void SampleDelegate(string input);
    ...
    //Method 1
    public void InputStringToDB(string input) 
    {
        //Input the string to DB
    }
    ...
    //Method 2
    public void UploadStringToWeb(string input)
    {
        //Upload the string to the web.
    }
    ...
    //Delegate caller
    public void DoSomething(string param1, string param2, SampleDelegate uploadFunction)
    {
        ...
        uploadFunction("some string");
    }
    ...
    //Method selection:  (assumes that this is in the same class as Method1 and Method2.
    if(inputToDb)
        DoSomething("param1", "param2", this.InputStringToDB);
    else
        DoSomething("param1", "param2", this.UploadStringToWeb);
