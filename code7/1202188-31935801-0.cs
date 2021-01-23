    public class SomeClass<TElement> where TElement : IProperty
    {
	    TElement _element;
	
	    public void SomeFunction()
        {
	    	_element.Property = someValue;
	    }
	
	    public TElement Element 
        {
		    get 
            {
			    return _element;
		    }
		    set 
            {
		    	_element = value;
		    }
	    }
    }
    public interface IProperty
    {
        SomeType Property { get; }
    }
