    public ActionResult _BookTime(BookTime bt)
            {
                
    
    			if(null != bt)
    			{
    				if(null!=Request.Form["Month"])
    				{
    					bt.Month = Request.Form["Month"].ToString();
    				}
    				else
    				{
    					throw new NullReferenceException("Month was null");
    				}					
    				if(null!=Request.Form["Date"])
    				{
    					/* if bt.Date is a date..what are you doing to make sure the form value is a date?? */
    					bt.Date = Request.Form["Date"].ToString();
    				}
    				else
    				{
    					throw new NullReferenceException("Date was null");
    				}				
    			}
    			else
    			{
    				throw new NullReferenceException("bt was null");
    			}
    
    			if(null!=db)
    			{
    			db.BookTimes.Add(bt);
                db.SaveChanges();
    			}
    			else
    			{
    				throw new NullReferenceException("Db was null");
    			}
    			return Redirect("Index");
            }
