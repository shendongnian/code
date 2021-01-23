        public class Pvec<T>
        {
    	    private List<T> p;
    
    	    public Pvec()
    	    {
                p = new List<T>();
    	    }
    	    public Pvec(uint n)
    	    {
    		    p = new List<T>((int)n);
    	    }
    	    public Pvec(uint n, T v)
    	    {
    		    p = new List<T>((int)n) { v };
    	    }
        }
