    <code> 
      // Create a new type of the entity I want
    Type t = typeof(T);
    
    T returnObject = new T();
    
    for (int i = 0; i < dataReader.FieldCount; i++) {
    	string colName = string.Empty;
    	colName = dataReader.GetName(i);
    	// Look for the object's property with the columns name, ignore case
    	PropertyInfo pInfo = t.GetProperty(colName.ToLower(), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
    
    	// did we find the property ?
    	if (pInfo != null) {
    		if (dataReader.Read()) {
    			object val = dataReader[colName];
    			// is this a Nullable<> type
    			bool IsNullable = (Nullable.GetUnderlyingType(pInfo.PropertyType) != null);
    			if (IsNullable) {
    				if (val is System.DBNull) {
    					val = null;
    				} else {
    					// Convert the db type into the T we have in our Nullable<T> type
    					val = Convert.ChangeType(val, Nullable.GetUnderlyingType(pInfo.PropertyType));
    				}
    			} else {
    				// Convert the db type into the type of the property in our entity
    				val = Convert.ChangeType(val, pInfo.PropertyType);
    			}
    			// Set the value of the property with the value from the db
    			pInfo.SetValue(returnObject, val, null);
    		}
    	}
    }
    
    </code> 
