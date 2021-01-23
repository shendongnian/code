    public virtual void Add(Control value)
    {
   	    // skipped stuff
 	    if (value.parent != null)
	    {
		    value.parent.Controls.Remove(value);
	    }
	    base.InnerList.Add(value);
        // many more
     }
