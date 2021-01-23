    public object Post(Currency currency)
    {
        ClientData clientData = new ClientData();
        validation.Errors = new List<string>(); // instantiate
        if (ModelState.IsValid)
        {
            new CurrencyProvider().Insert(currency);
            clientData.IsValid = true;
            clientData.Data = new CurrencyProvider().GetAll();
        }
        else
        {
            Validation validation = new Validation();
            foreach (var modelState in ModelState)
            {
                foreach (var error in modelState.Value.Errors)
                {
                    validation.Errors.Add(error.ErrorMessage);
                }
            }
            clientData.IsValid = false;
            clientData.Data = validation;
        }
        return clientData;
    }
