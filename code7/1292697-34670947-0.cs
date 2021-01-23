    var listFiled = new List<TaxInfoTaxFiled>();
    for(var item = 0; item < objValue.Count ; item++)
    {
        listFiled.Add(new TaxInfoTaxFiled
        {
            TaxInfoTaxFieldID = TaxInfoTaxFieldObj,
            TaxFieldID = new Guid(Alist[item]),
            FieldValue = objValue[item]
        });
    }
