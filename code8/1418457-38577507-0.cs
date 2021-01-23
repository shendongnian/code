    using (MyDataContext dc = new MyDataContext())
    {
    	var result = 
    		(from test in dc.Tests
    		let blade = (from t in dc.Blade where t.id == test.DeviceID)
    		let engine = (from t in dc.Engine where t.id == test.DeviceID)
    		let diode = (from t in dc.Diode where t.id == test.DeviceID)
    		select new {
    			test.ID,
    			Device = 
    					(blade.Count() > 0 ? blade.FirstOrDefault().Name : "")  + 
    					(engine.Count() > 0 ? engine.FirstOrDefault().Name : "") + 
    					(diode.Count() > 0 ? diode.FirstOrDefault().Name : "")
    		}
    		);
    				 
    				 
    }
