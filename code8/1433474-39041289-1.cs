    public class PersonViewModel
    {
    	public static Expression<Func<Person, PersonViewModel>> FromPerson
    	{
    		get
    		{
    			return p => new PersonViewModel
    			{
    				Name = p.FirstName,
    				SurName = p.LastName
    			};
    		}
    	}
    	
    	public string Name { get; set; }
    	public string SurName { get; set; }
    	public static PersonViewModel CreateViewModel(Person original)
    	{
    		var func = FromPerson.Compile();
    		var vm = func(original);
    		
    		return vm;
    	}
    }
