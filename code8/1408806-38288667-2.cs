    public void Insert(object input)
    {
       // DB setup code goes here
       var parameter = new SqlParameter("@input", input);
       // Finish DB code here
    }
    // Call it like this
    myClass.Insert(integerInputData);
    myClass.Insert(stringInputData);
