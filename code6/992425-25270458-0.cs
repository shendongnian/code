    class Identity
    {
        private int x;
        public Identity(Identity that)
        {
            this.x = that.x;
        }
    }
    
    class OrgnaizationIdentity : Identity 
    {
        public OrgnaizationIdentity(Identity that) : base(that) { ... }
    }
