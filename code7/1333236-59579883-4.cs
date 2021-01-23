        public User(Person person, string email, string username, string password, bool isActive)
		{
			Person = person;
			Email = email;
			Username = username;
			Password = password;
			IsActive = isActive;					
		}
		public Person Person { get; }          
        public string Email { get;  }
        public string Username { get; }
        public string Password { get; }
		public bool IsActive { get; }
