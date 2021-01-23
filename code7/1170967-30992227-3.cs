    public sealed class MyClass : IDisposable
	{
	  private Library _lib;
	  private Function _func;
	  public MyClass(string dllPath)
	  {
		_lib = new Library(dllPath); // If this fails, we throw here, and we don't need clean-up.
		try
		{ 
		  _func = new Function(_lib, "MyFunction");
		  try
		  {
			SomeMethodThatCanThrowJustToComplicateThings();
		  }
		  catch
		  {
			_func.Dispose();
			throw;
		  }
		}
		catch
		{
		  _lib.Dispose();
		  throw;
		}
	  }
	  public void Dispose()
	  {
		_func.Dispose();
		_lib.Dispose();
	  }
	}
