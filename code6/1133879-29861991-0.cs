	void Main()
	{
		AutoMapper.Mapper.CreateMap<User, MyUser>()
			.ForMember(myUsers => myUsers.Name, users => users.MapFrom(property => string.Format("{0} {1}",property.FirstName, property.LastName)));
			
		User user = new User
		{
			FirstName = "James",
			LastName = "Doe",
			DateOfBirth = DateTime.UtcNow
		};
		
		
		MyUser myUser = AutoMapper.Mapper.Map<MyUser>(user);
	}
	
	public class MyUser
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public DateTime DateOfBirth { get; set; }
		
	}
	
	public class User 
	{
		public User()
		{
			this.Id = Guid.NewGuid().ToString();
		}
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
	}
	
	
