    void Main()
    {
    	User obj = new User();
    	obj.FirstName = "sujit";
    	obj.LastName = "kumar";
    	obj.Address = "Bangalore";
    	obj.Mobile = null;
    
    	var config = new MapperConfiguration(cfg => cfg.CreateMap<User, Patient>()
    		.ForMember(emp => emp.Name, map => map.MapFrom(p => p.FirstName + " " + p.LastName))
    		.ForMember(dest => dest.Location, source => source.MapFrom(x => x.Address))
    		.ForMember(dest => dest.phone, source => source.MapFrom(x => x.Mobile))
    		.ForMember(dest => dest.phone, source => source.NullSubstitute("8099000078")));
    		
        var mapper = config.CreateMapper();
    	var result = mapper.Map<User, Patient>(obj);
    	
    	result.Dump();
    }
    
    public class User
    {
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    	public string Address { get; set; }
    	public string Mobile { get; set; }
    }
    public class Patient
    {
    	public string Name { get; set; }
    	public string Location { get; set; }
    	public int age { get; set; }
    	public string phone { get; set; }
    }
