    public virtual bool? IsInternal { get; set; }
    
    Map.Property(p => p.IsInternal, u =>
    	        {
    	            u.Update(false);
    	            u.Insert(false);
    	        });
