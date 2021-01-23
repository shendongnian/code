    private string name;
    public string Name
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new NoNullAllowedException("Name is mandatory");
            }
            else
            {
                this.name = value;
            }
        }
    }
