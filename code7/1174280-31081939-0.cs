    void Main()
    {
    	List<Student> stu = new List<Student>(){
    		new Student("A", "B", new List<int>{ 2, 3, 4, 5, 2 }),
    		new Student("B", "A", new List<int>{ 2, 3, 4, 5, 6 }),
    		new Student("B", "A", new List<int>{ 2, 3, 4, 5, 4 })
    		};
    	
    	var qry = stu
    		.OrderBy(s=>s.FirstName)
    		.ThenBy(s=>s.LastName)
    		.Where(s=>s.Grades.GroupBy(r=>r).Any(g=>g.Count(a=>a==2)>1));
    	//qry.Dump();
    	
    }
    
    // Define other methods and classes here
    public class Student
    {
    	public Student(string sFName, string sLName, List<int> grades)
    	{
    		FirstName = sFName;
    		LastName = sLName;
    		Grades = grades;
    	}
    	
    	public string FirstName{get;set;}
    	public string LastName{get;set;}
    	public List<int> Grades{get;set;}
    }
