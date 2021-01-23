    void Main()
    {
        FunctionThatDoesStuff(SetField);
    }
    void FunctionThatDoesStuff(Action<IFieldsetter<Contact>> action)
    {
        var setter = new IFieldsetter<Contact>();
        action(setter);
    }
    void SetField(IFieldsetter<Contact> setter)
    {
    }
