    public virtual string GetEnumName(object value)
    {
        if (value == null)
            throw new ArgumentNullException("value");
        if (!IsEnum)
            throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
        Contract.EndContractBlock();
        Type valueType = value.GetType();
        if (!(valueType.IsEnum || Type.IsIntegerType(valueType)))
            throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnumBaseTypeOrEnum"), "value");
        Array values = GetEnumRawConstantValues();
        int index = BinarySearch(values, value);
        if (index >= 0)
        {
            string[] names = GetEnumNames();
            return names[index];
        }
        return null;
    }
