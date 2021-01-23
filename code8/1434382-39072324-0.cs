    public T UpdateMapFetcher<T>(int stationID, int typeID) {
        // To allow parsing to the generic type T:
        var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
        if(converter != null)
        {
            return (T)converter.ConvertFromString(returnvalue.ToString());
        }    
        else
        {
            return default(T);
        }
    }
