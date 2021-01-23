		class EnhancedPerson : Person {
			public int Age { get; set; }
			public EnhancedPerson(string name) : base(name) { }
		}
		class EnhancedPerson : Person {
			public int Age { get; set; }
			public EnhancedPerson() : base(null) { }
		}
