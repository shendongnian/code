    private SomeClass TryToCreateItem()
    {
        try 
        {
            return SomeClass.CreateItem(target);
        } 
        catch(CustomException ex) 
        {
            // notify UI of error
        }
        return null;
    }
    public void DoSomething(string foo) 
    { 
        SomeClass obj = TryToCreateItem(); 
        if (obj != null) {
          // do something with `obj`
        }
