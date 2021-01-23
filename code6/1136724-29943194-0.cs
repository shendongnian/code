                List<DateTime> dates = new List<DateTime>();
    			//filling the list somehow
    			List<DateTime> dates2 = new List<DateTime> ();
    			foreach (var v in dates) {
    				if (!dates2.Contains (v.Date)) {
    					dates2.Add (v.Date);
    				}
    			}
    			dates = dates2;
