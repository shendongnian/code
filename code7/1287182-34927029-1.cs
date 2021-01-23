    class Indicator<T> where T : Control
	{
		static Indicator()
		{
			{
				if (typeof(T).GetProperties().All(p => p.Name != "Image" || p.PropertyType != typeof(Image)))
					throw new Exception(typeof(T).Name + " is not a supported generic type argument because it does not have an Image property");
			}
        }
	    private readonly T _control;
	    public Indicator(T control)
	    {
		    _control = control;
	    } 
    }
