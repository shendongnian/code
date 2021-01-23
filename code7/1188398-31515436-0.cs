    public Emails(IEnumerable<Email> emails)
    {
            List<Email> invalid = new List<Email>();
            foreach (var e in emails)
            {
                //   Will throw System.FormatException:
                //     address is not in a recognized format.
                try
                {
                    var addr = new System.Net.Mail.MailAddress(e.Address);
                    Add(e);
                }
                catch (FormatException)
                {
                    // The address was invalid. Add to a list of invalid
                    // addresses
                    invalid.Add(e);
                }
            }
    }
