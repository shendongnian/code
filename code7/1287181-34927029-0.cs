    class Indicator<T> where T : Control
	{
		static Indicator()
		{
			{
				if (typeof(T).GetProperties().All(p => p.Name != "Image" || p.PropertyType != typeof(Image)))
					throw new TypeInitializationException(typeof(Indicator<T>).FullName,
						new ArgumentException("This type of control is not supported because it does not have an Image property"));
			}
        }
	    private readonly T _control;
	    public Indicator(T control)
	    {
		    _control = control;
	    } 
    }
