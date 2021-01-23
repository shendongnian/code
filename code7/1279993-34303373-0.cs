    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using CorporateWeb.API.Model;
    namespace CorporateWeb.API.DAL
    {
	    public partial class context : DbContext
    	{
	    	public context() : base("name=Corporate_WebEntities")
		    {
			    this.Configuration.LazyLoadingEnabled = false;
    			this.Configuration.ProxyCreationEnabled = false;
	    	}
    	}
    }
