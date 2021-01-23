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
		list.Dump();
		
		string keyword = "E"; //Example of search keyword
		list = Search(list, keyword);
        list.Count.Dump(); //returns 3
	}
	
	public IList<Student> Search(IList<Student> list, string keyword)
	{
        //outputs a list containing Mike, Steve and Jane student objects
		return list.Where(e => e.Name.ToLower().Contains(keyword.ToLower())).ToList().Dump();
	}
		
	public class Student
	{
		public string Name {get;set;}
		public string MatricNo {get;set;}
		public string Gender {get;set;}
	}
