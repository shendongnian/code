    private void MyMethod()
    {
        string something = "";
        var props = typeof (MyClass).GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(NowThatsAnAttribute)));
        //this is where things get messy
        //here's sudo code of what I want to do
        //I KNOW THIS IS NOT VALID SYNTAX
        foreach(prop in props)
        {
            string attribVal = object value = GetPropertyAttributeValue<MyClass,NowThatsAnAttribute>("HeresMyString", prop.Name);
            //my first idea was this
            if(attribVal == "A")
            {
                something = "A";
            } 
            else if(attribVal == "B")
            {
                something = "B";
            }
       
        }
        //do stuff with something
    }
