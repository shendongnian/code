    private string groupNameValue = Guid.NewGuid().ToString();
    public string GroupNameValue
    {
        protected get { return this.groupNameValue; }
        set
        {
            this.SetProperty(ref this.groupNameValue, value);
        }
    }
