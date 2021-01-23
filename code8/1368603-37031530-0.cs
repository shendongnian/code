    using (NewEntities dc = new NewEntities())
    {
    	var visits = (from a in dc.Visits
    			  join b in dc.Clients on a.clientID equals b.clientID
    			  select new 
    			  {
    				  a,
    				  b.Name,b.Surname,b.Address,
    			  });
    	
    	myGridView.DataSource = visits;
    	myGridView.DataBind();
    }
