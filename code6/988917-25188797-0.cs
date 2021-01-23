    private IList<T> GetDictionaryListByName<T>(string dictionaryName)
        where T : new() // passed T must have parameterless consctructor
    {
        using (var session = DbManager.SessionFactory.OpenSession())
        {
            var result = session
                 .QueryOver<IDictionary>(dictionaryName)
                 .List<T>();
            if(result.Any())   // if there is any result 
            {
                return result; // return that list
            }
        }
        return new List<T> {new T() }; // return new List with new T()
    }
