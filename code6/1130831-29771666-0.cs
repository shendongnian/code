    private bool Validate(string s, out string error)
    {
        if (string.IsNullOrEmpty(s))
        {
            error = "s is null";
            return false;
        }
        else
        {
            error = null;
            return true;
        }
    }
