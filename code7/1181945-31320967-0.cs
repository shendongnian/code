    private void Validate(DataTypeEnum dataType, object value, ...)
    {
            var Validator = new Dictionary<DataTypeEnum , Action >
            {
                { DataTypeEnum.Number, () => Validate(Convert.ToDouble(value)) },
                { DataTypeEnum.Decimal, () => Validate(Convert.ToDecimal(value)) },
                { DataTypeEnum.DateTime, () => Validate(Convert.ToDateTime(value)) }
            }
            Validator[dataType]();
    }
    private void (Decimal value)
    {
        //Validate
    }
    private void (DateTime value)
    {
        //Validate
    }
