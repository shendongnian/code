    public class Dirty<T>
    {
    	public Dirty(Func<T> valueFactory)
    	{
    		this.valueFactory = valueFactory;
            dirty = true;
    	}
    	
        private Func<T> valueFactory;
        private bool dirty;
        private T value;
        public T Value
        {
            get
            {
                if (dirty)
                {
                    value = valueFactory();
                    dirty = false;
                }
    			
                return value;
            }
        }
    }
