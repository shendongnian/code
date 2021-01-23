    public bool IsStyleAvailable(FontStyle style)
    {
    	int num2;
    	int num = SafeNativeMethods.Gdip.GdipIsStyleAvailable(new HandleRef(this, this.NativeFamily), style, out num2);
    	if (num != 0)
    	{
    		throw SafeNativeMethods.Gdip.StatusException(num);
    	}
    	return num2 != 0;
    }
