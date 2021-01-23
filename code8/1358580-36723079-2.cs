    public string UpdateProperty(string baseText, string property, string newValue)
    {
        // look for "|PropertyName: value|" and split it into parts for replacement
        Regex regex = new Regex(string.Format(@"(\|{0}:(?: ?))([^|]*)(\|)", property));
        return regex.Replace(baseText, string.Format("$1{0}$3", newValue));
    }
    o.Product = UpdateProperty(orderText, "Huidige provider", "new value");
