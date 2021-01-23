    private string name; // <<<<==== Add this
    public string Name
    {
        get { return name; } // <<<<====== change
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new NoNullAllowedException("Name is mandatory");
            }
            else
            {
                name = value; // <<<<==== change
            }
        }
    }
