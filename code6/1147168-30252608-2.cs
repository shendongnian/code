    @{
    
        string[] showColumns = new string[3] {"Property1", "Property2", "Property3"};
        dynamic myobject = new System.Dynamic.ExpandoObject();
        myobject.Property1 = "First Property!";
        myobject.Property2 = "Second Property!";
        myobject.Property3 = "Third Property!";
    
        for (int i = 0; i < showColumns.Length; i++)
        {
            var propertyValues = (IDictionary<string, object>)myobject;
            <p>@propertyValues[showColumns[i]]</p>
        }
    }
