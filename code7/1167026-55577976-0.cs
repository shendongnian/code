c#
public string ConcatenatedUserNumbers
    {
        get
        {
            if (ContactNumbers != null && ContactNumbers.Any())
            {
                return string.Join("; ", ContactNumbers.Select(a => a.Number));
            }
            return string.Empty;
        }
    }
Here it is as a lambda 
c#
    public string ConcatenatedUserNumbers =>
        (this.ContactNumbers != null && this.ContactNumbers .Any())
        ? string.Join("; ", this.ContactNumbers .Select(a => a.Number))
        : string.Empty;
