    public class AGuage
    {
        private float _value;
    	private Subject<float> _values = new Subject<float>();
    
        public float Value
        {
            get { return _value; }
            set
            {
                _value = value;
    			_values.OnNext(value);
            }
        }
    
    	public IObservable<float> Values
    	{
    		get { return _values.AsObservable(); }
    	}
    }
