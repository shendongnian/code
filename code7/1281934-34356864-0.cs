    public override bool Equals(Process p)
    {
        // If parameter is null return false:
        if ((object)p == null)
        {
            return false;
        }
        // Return true if the fields match:
        return (ID == p.ID);
    }
