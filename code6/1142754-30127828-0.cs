    void Main()
    {
    	string p = "PASS";
    	var c = GetEnumNameByString<DocumentType>(p, typeof(DocumentExtendedType));
    }
    
    public enum DocumentType{ IdCard=0, Passport, DriversLicense }
    public enum DocumentExtendedType { ID = 0, PASS, DRIVERS, NONE }
    
    public TEnum GetEnumNameByString<TEnum>(string name, Type type)
    {
    	int index = Enum.Parse(type, name).GetHashCode();
    	if(Enum.IsDefined(typeof(TEnum), index))
    	{
    		return (TEnum)Enum.GetValues(type).GetValue(index);
    	}
    	else
    	{
    		throw new IndexOutOfRangeException();
    	}
    }
