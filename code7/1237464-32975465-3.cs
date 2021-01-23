    private bool SearchProperties<T>(T part, string searchString) where T : Part
    {
        var props = typeof(T).GetProperties();
        foreach (var prop in props)
        {
            var value = prop.GetValue(part);
            if (value is IEnumerable)
            {
                // special handling for collections
            }
            else if(value != null)
            {
				object searchValue = null;
				try
				{
					searchValue = TypeDescriptor.GetConverter(value).ConvertFromString(searchString);
				} catch {}
				if (searchValue != null && object.Equals(value, searchValue))
					return true;
            }
        }
        return false;
    }
