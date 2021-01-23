    class MyClass
    {
    
    // ...other members 
    public static implicit operator KeyValuePair<string,MyClass>(MyClass obj)
    {
        return new KeyValuePair<string,MyClass>(obj.Name,obj);
    }
    public static implicit operator MyClass(KeyValuePair<string,MyClass> kvp)
    {
        return kvp.Value;
    }
