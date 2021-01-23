  	class Person {
		public string Active { get; set; }
		public string Name { get; set; }
		public string From { get; set; }
		public string Age { get; set; }
		public string Gender { get; set; }
		public string Country { get; set; }
		public Person(string active, string name, string from, string age, string gender, string country) {
			Active = active;
			Name = name;
			From = from;
			Age = age;
			Gender = gender;
			Country = country;
		}
	}
	class PersonList : Person {
			public PersonList(string active, string name, string from, string age, string gender, string country) : base(active, name, from, age, gender, country) {}
	}
	private void btnSubmit_Click(object sender, EventArgs e) {
		PersonList newPerson = new PersonList(
			txtActive.Text,
			txtName.Text,
			txtFrom.Text,
			txtAge.Text,
			txtGender.Text,
			txtCountry.Text);
		if (newPerson.check())
			erase();
	}
