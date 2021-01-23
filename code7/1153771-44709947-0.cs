    public static bool IsValidEmailAddress(string emailAddress, bool verifyDomain = true)
    {
        var result = false;
        if (!string.IsNullOrWhiteSpace(emailAddress))
        {
            try
            {
                // Check Format (Offline).
                new MailAddress(emailAddress);
                if (verifyDomain)
                {
                    // Check that domain is valid (Online).
                    result = Dns.GetHostAddresses(emailAddress.Split("@".ToArray()).Last())?.Any() == true;
                }
                else
                {
                    result = true;
                }
            }
            catch (SocketException)
            {
                result = false;
            }
            catch (FormatException)
            {
                result = false;
            }
        }
        return result;
    }
