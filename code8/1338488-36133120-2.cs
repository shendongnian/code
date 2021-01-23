    Dictionary<PaymentTypeEnum, char> types = new Dictionary<PaymentTypeEnum, char>();
    
    types[PaymentTypeEnum.PhonePayment_IVR] = '9';
    types[PaymentTypeEnum.eCollectPayment] = '5';
    types[PaymentTypeEnum.CancelPayment] = 'C';
    public char GetPaymentType(PaymentTypeEnum pt)
    {
        if(types.ContainsKey(pt))
        {
            return types[pt];
        }
    
        return default(char); // assuming (char)0 is meaningless in this context...otherwise...
        throw new InvalidArgumentException(...);
    }
