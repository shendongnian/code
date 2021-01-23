	catch (ArgumentOutOfRangeException ex)
	{
		if (ex.Message == "Year, Month, and Day parameters describe an un-representable DateTime.")
		{
			pi.SetValue(myClass, null, null);
			var odbcdatareader = typeof(OdbcDataReader);
			var dataCache = odbcdatareader.GetField("dataCache",
				BindingFlags.Instance | BindingFlags.NonPublic);
			var dbcache = dataCache.GetValue(record);
			var valuesfield = dbcache.GetType()
				.GetField("_values", BindingFlags.Instance | BindingFlags.NonPublic);
			var values = (object[]) valuesfield.GetValue(dbcache);
			values[i] = new DateTime(1, 1, 1);
			valuesfield.SetValue(dbcache, values);
		}
		else
			throw;
	}
