    string[] _supportedAttributes = new string[] { "MaxUsers", "maxusers" };
    /// <summary>
    /// Allowed attributes for this trace listener.
    /// </summary>
    protected override string[] GetSupportedAttributes() {
        return _supportedAttributes;
    }
    /// <summary>
    /// Get or set the value of Max Users Attribute 
    /// </summary>
    public int MaxUsers {
        get {
            var maxUsers = -1; // You can set a default if you want
            if (Attributes.ContainsKey("maxusers")) {
                int.TryParse(Attributes["maxusers"], out maxUsers);
            }
            return maxUsers;
        }
        set {
            Attributes["maxusers"] = value.ToString(CultureInfo.InvariantCulture);
        }
    }
