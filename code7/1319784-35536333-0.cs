    public string Name
    {
        get { return this.Name; } // <<<<====== HERE
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new NoNullAllowedException("Name is mandatory");
            }
            else
            {
                this.Name = value; // <<<<==== HERE
            }
        }
    }
