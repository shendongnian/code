    void Main()
	{
		IList<Student> list = new List<Student>();
		
		Student students1 = new Student();
		students1.Name = "Mike";
		students1.MatricNo = "12345";
		students1.Gender = "Male";
		list.Add(students1);
		
		Student students2 = new Student();
		students2.Name = "Steve";
		students2.MatricNo = "12345";
		students2.Gender = "Male";
		list.Add(students2);
		
		Student students3 = new Student();
		students3.Name = "Jane";
		students3.MatricNo = "12345";
		students3.Gender = "Male";
		list.Add(students3);
		
		var test1 = Search(list, "mik"); //returns Mike
		var test2 = Search(list, "MIK"); //returns Mike
		var test3 = Search(list, "iKe"); //returns Mike
		//all three are the same
	}
	
	public IList<Student> Search(IList<Student> list, string keyword)
	{
        return list.Where(e => e.Name.ToLower().Contains(keyword.ToLower())).ToList();
	}
		
	public class Student
	{
		public string Name {get;set;}
		public string MatricNo {get;set;}
		public string Gender {get;set;}
	}
