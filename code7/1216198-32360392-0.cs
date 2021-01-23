    private string phoneNumber;
    public string PhoneNumber
    {
        get { return phoneNumber; }
        set { phoneNumber = !string.IsNullOrWhiteSpace(value) ? Regex.Replace(value, @"[^0-9]", "") : null; }
    }
