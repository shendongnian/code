    public static void Main(string[] args)
    {
        var attr = new EmailAddressAttribute();
        var email = "email@email";
        var isValid = attr.IsValid(email); // false with "net452", true with "netcoreapp1.0"
    }
