    public StatusDescription {
        get {
            if (statusCode == 15) {
                return "Stock Room in Process.";
            }
            // etc, etc.
            return string.Empty;
        }
    }
