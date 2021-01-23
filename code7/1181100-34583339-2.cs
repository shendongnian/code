    string[] _supportedAttributes = new string[] { "MaxUsers", "maxusers", "maxUsers" };
    /// <summary>
    /// Allowed attributes for this trace listener.
    /// </summary>
    protected override string[] GetSupportedAttributes() {
        return _supportedAttributes;
    }
    /// <summary>
    /// Get the value of Max Users Attribute 
    /// </summary>
    public int MaxUsers {
        get {
            var maxUsers = -1; // You can set a default if you want
            var key = Attributes.Keys.Cast<string>().
                FirstOrDefault(s => string.Equals(s, "maxusers", StringComparison.InvariantCultureIgnoreCase));
            if (!string.IsNullOrWhiteSpace(key)) {
                int.TryParse(Attributes[key], out maxUsers);
            }
            return maxUsers;
        }
    }
