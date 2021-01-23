    var q =(from t in Trackings
    		group t by t.ClientID into g
    		let lastTracking = g.OrderByDescending(x => x.TrackDate).FirstOrDefault()
    		select new 
    		{
    			ClientID = g.Key, 
    			Date = lastTracking.TrackDate,
    			Memo = lastTracking.Memo
    		}).ToList();
