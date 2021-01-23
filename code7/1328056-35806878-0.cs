    public static string FormatSSN(this string ssn, string clientIdentity)
    {
        switch (clientIdentity)
        {
            case "client1Identifier":
                return ssn..... // Format logic for client 1
                break;
            case "client2Identifier":
                return ssn..... // Format logic for client 2
                break;
            default:
                return ssn..... // Default Format logic
                break;
        }
    }
