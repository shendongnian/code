    public class PersonReferenceResolver : IReferenceResolver
    {
        private readonly IDictionary<string, Person> _objects = 
            new Dictionary<string, Person>();
    
        public object ResolveReference(object context, string reference)
        {
    		Person p;
    		if (_objects.TryGetValue(reference, out p))
            {
                //May be better to clone your class here...
    			return new Person
    			{
    				Name = p.Name,
    				BirthDate = p.BirthDate,
    				LastModified = p.LastModified
    			};
    		}
    
    		return null;
        }
    
        public string GetReference(object context, object value)
        {
            Person p = (Person)value;
            _objects[p.Name] = p;
    
            return p.Name;
        }
    
        public bool IsReferenced(object context, object value)
        {
            Person p = (Person)value;
    
            return _objects.ContainsKey(p.Name);
        }
    
        public void AddReference(object context, string reference, object value)
        {
            _objects[reference] = (Person)value;
    	}
    }
