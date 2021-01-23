    public bool priceRegex (string parameter)
    {
        Regex regexPrice = new Regex(@"^[0-9]+(\.[0-9][0-9]?)?");
        return regexPrice.IsMatch(parameter);
    }
