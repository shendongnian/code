	void Main()
	{
		var result = EmployeeSkills
			.GroupBy(x => x.YearsOfExperience)
			.OrderByDescending(x => x.Key)
			.Take(1)
			.SelectMany(x => x)
			.Select(x => Employees
					.Where(y => y.EmployeeID == x.EmployeeID)
					.Select(y => y.FirstName + " " + y.LastName).Single()
			);
			
		result.Dump();
	}
	public class Employee 
	{
		public int EmployeeID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string HomePhone { get; set; }
		public bool Active { get; set; }
	}
	
	public class Skill 
	{
		public int SkillID { get; set; }
		public string Description { get; set; }
		public bool RequiresTicket { get; set; }
	}
	
	public class EmployeeSkill 
	{
		public int EmployeeSkillID { get; set; }
		public int EmployeeID { get; set; }
		public int SkillID { get; set;}
		public int Level {get; set;}
		public int YearsOfExperience {get; set;}
	}
	
	public List<Employee> Employees = new List<Employee> {
		new Employee { EmployeeID = 1, FirstName = "Wallace",  LastName = "Daniels" },
		new Employee { EmployeeID = 2, FirstName = "Monique",  LastName = "Flowers" },
		new Employee { EmployeeID = 3, FirstName = "Woodrow",  LastName = "Gross" },
		new Employee { EmployeeID = 4, FirstName = "Ed",       LastName = "Barton" },
		new Employee { EmployeeID = 5, FirstName = "Marjorie", LastName = "Smith" },
		new Employee { EmployeeID = 6, FirstName = "Dora",     LastName = "Yates" },
		new Employee { EmployeeID = 7, FirstName = "Sylvia",   LastName = "Bush" },
		new Employee { EmployeeID = 8, FirstName = "Florence", LastName = "Webster" },
		new Employee { EmployeeID = 9, FirstName = "New",      LastName = "Guy" }	
	};
	
	public List<Skill> Skills = new List<Skill>() {
		new Skill { SkillID = 1, Description = "Working", RequiresTicket = false }
	};
	
	public List<EmployeeSkill> EmployeeSkills = new List<EmployeeSkill>() {
		new EmployeeSkill { EmployeeSkillID = 1,  EmployeeID = 1, SkillID = 1, Level = 3, YearsOfExperience = 8 },
		new EmployeeSkill { EmployeeSkillID = 2,  EmployeeID = 2, SkillID = 1, Level = 1, YearsOfExperience = 8 },
		new EmployeeSkill { EmployeeSkillID = 3,  EmployeeID = 3, SkillID = 1, Level = 3, YearsOfExperience = 8 },
		new EmployeeSkill { EmployeeSkillID = 4,  EmployeeID = 4, SkillID = 1, Level = 1, YearsOfExperience = 8 },
		new EmployeeSkill { EmployeeSkillID = 5,  EmployeeID = 5, SkillID = 1, Level = 2, YearsOfExperience = 8 },
		new EmployeeSkill { EmployeeSkillID = 6,  EmployeeID = 6, SkillID = 1, Level = 1, YearsOfExperience = 8 },
		new EmployeeSkill { EmployeeSkillID = 7,  EmployeeID = 7, SkillID = 1, Level = 3, YearsOfExperience = 8 },
		new EmployeeSkill { EmployeeSkillID = 8,  EmployeeID = 8, SkillID = 1, Level = 1, YearsOfExperience = 8 },
		new EmployeeSkill { EmployeeSkillID = 9, EmployeeID = 9, SkillID = 1, Level = 1, YearsOfExperience = 1 },
	};
	
