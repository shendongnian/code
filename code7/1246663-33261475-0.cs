    private bool PopulateList<T>(Dictionary<string, string> itemProperties, List<T> list)
                     where T : new();
    {
            
            var baseObj = new T();
            //Code here populates the object that will be added to the collection.
    
            list.Add(baseObj); <--- This obviously doesn't work.
            return true;
    }
