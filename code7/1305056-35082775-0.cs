    public myAttribute(string description, object param1, object param2, Type passedType)
    {
        this.myAttributeDescription = description;
        this.SomePropertyWhichIsAnEnum = (Enum)Enum.ToObject(passedType, param1));
        this.SomeOtherPropertyWhichIsAnEnum = (Enum)Enum.ToObject(passedType, param2)
    }
}
