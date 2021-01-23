    private static bool? _isJITAvailable = null;
    public static bool IsJITAvailable()
    {
        if(_isJITAvailable == null)
        {
            try
            { 
                //This crashes on iPhone
                typeof(GenericClass<>).MakeGenericType(typeof(int));
                _isJITAvailable = true;
            }
            catch(Exception)
            {
                _isJITAvailable = false;
            }
        }
       
        return _isJITAvailable.Value;
    }
