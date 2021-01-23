    public static bool IsValidEmailAddress(string emailAddress, bool verifyDomain = true)
    {
        var result = false;
        if (!string.IsNullOrWhiteSpace(emailAddress))
        {
            try
            {
                // Check Format (Offline).
                var addy = new MailAddress(emailAddress);
                if (verifyDomain)
                {
                    // Check that a valid MX record exists (Online).
                    result = new DnsStubResolver().Resolve<MxRecord>(addy.Host, RecordType.Mx).Any();
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
