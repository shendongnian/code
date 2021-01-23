    		public float HydroControlPanel ()
    		{
                turbina1 = t1Bool ? 2 : 0;
                turbina2 = t2Bool ? 3 : 0;
                turbina3 = t3Bool ? 1 : 0;
    			
                prod = turbina1 + turbina2 + turbina3;
    			return prod;
    		}
    	}
    }
