    private ICollection<Site> _sites;
    public virtual ICollection<Site> Sites 
    {
    	get{ return _sites ?? (_sites = new HashSet<Site>()); }
    	set{ _sites = value; }
    }
