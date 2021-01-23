    private readonly Dictionary<DataTypeEnum , Action > Validator = new Dictionary<DataTypeEnum , Action >
            {
                { DataTypeEnum.Number, () => Validate(Convert.ToDouble((string)value)) },
                { DataTypeEnum.Decimal, () => Validate(Convert.ToDecimal((string)value)) },
                { DataTypeEnum.DateTime, () => Validate(Convert.ToDateTime((string)value)) },
                // ...
            }
    private void Validate(DataTypeEnum dataType, object value, ...)
    {
        Validator[dataType](); // Gets the Action and Invokes it
    }
    private void Validate (Decimal value)
    {
        //Validate
    }
    private void Validate (DateTime value)
    {
        //Validate
    }
    //...
