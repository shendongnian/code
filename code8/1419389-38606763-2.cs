    public string NameAndDescription
    {
        get
        {
            if (string.IsNullOrEmpty(this.Description))
            {
                return this.Name;
            }
            else
            {
                return this.Name + " (" + this.Description + ")";
            }
        }
    }
