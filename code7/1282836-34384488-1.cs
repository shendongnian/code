    public class Pvec<T>
    {
	    private List<T> p;
	    public Pvec()
	    {
            p = new List<T>();
	    }
	    public Pvec(int n)
	    {
		    p = new List<T>(n);
	    }
	    public Pvec(int n, T v)
	    {
		    p = new List<T>(n) { v };
	    }
    }
