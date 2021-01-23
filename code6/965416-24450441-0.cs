    public IDictionary<string, object> Arguments
    {
        get
        {
            MasterPageType master = this.Page.Master as MasterPageType;
            if (master != null)
            {
                return master.Arguments;
            }
            else
            {
                return null;
            }
        }
    }
