	public bool IsConvertibleTo<T>(object value)
	{
		try 
		{
			T convertedValue = (T)Convert.ChangeType(value, typeof(T));
			return true;
		}
		catch (InvalidCastException)
		{
			return false;
		}
		catch (FormatException)
		{
			return false;
		}
		catch (OverflowException)
		{
			return false;
		}
	}
