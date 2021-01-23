    public class PersonNameResolver : ValueResolver<Person, PersonDTO>
    {
    	protected override PersonDTO ResolveCore(Person source)
    	{
    		return new PersonDTO
    		{
    			FirstName = source.FirstName,
    			LastName = source.LastName
    		};
    	}
    }
