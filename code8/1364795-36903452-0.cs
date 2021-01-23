    public abstract NameBase : EntityBaseDm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FormattedName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
