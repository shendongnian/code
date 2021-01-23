    [XmlType("Phone")]
	public class Phone
	{
		[XmlAttribute("type")]
		public string Type { get; set; }
		[XmlText]
		public string Value { get; set; }
	}
	[XmlType("Employee")]
	public class Employee
	{
		[XmlElement("EmpId", Order = 1)]
		public int Id { get; set; }
		[XmlElement("Name", Order = 2)]
		public string Name { get; set; }
		[XmlElement(ElementName = "Phone", Order = 3)]
		public Phone phone_home { get; set; }
		[XmlElement(ElementName = "Phone", Order = 4)]
		public Phone phone_work { get; set; }
		public Employee() { }
		public Employee(string home, string work)
		{
			phone_home = new Phone()
			{
				Type = "home",
				Value = home
			};
			phone_work = new Phone()
			{
				Type = "work",
				Value = work
			};
		}
    public static List<Employee> SampleData()
		{
			return new List<Employee>()
		{
			new Employee("h1","w1"){
				Id   = 1,
				Name = "pierwszy",
			},
			new Employee("h2","w2"){
				Id   = 2,
				Name = "drugi",
			}
		};
		}
	}
