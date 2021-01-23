    Func<dynamic, dynamic> DynamicProperty(Func<dynamic, dynamic> selector)
    {
        return x =>
        {
            try
            {	        
                return selector(x);
            }
            catch (RuntimeBinderException)
            {
                return null;
            }
        };
    }
