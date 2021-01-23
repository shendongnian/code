    public class MyNewClass
    {
    	public delegate void procfunc(ImagingDefs.V2fT2f[] quad,float t);
    
        public class Filter
        {
            public procfunc func;
            public procfunc degen;
        };
    
        public Filter[] filter;
    	
    	public MyNewClass()
    	{
    		filter = new Filter[]
    		{
    			new Filter { func = brightness },
    			new Filter { func = contrast },
    			new Filter { func = extrapolate, degen = greyscale },
    			new Filter { func = hue },
    			new Filter { func = extrapolate, degen = blur } // The blur could be exaggerated by downsampling to half size
    		};
    	}	
    }
