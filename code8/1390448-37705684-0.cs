    // I'd create a model to start with
    
    public class Student
    {
    	public int StudentID {get; set;}
    	public string StudentName {get; set;}
    	public string Email {get; set;}
    }
    // Followed by a Controller to store the data:
    
    public class StoreStudentOnAppClose()
    {
    	public void StoreStudents()
    	{
           List<Student> studentList = new List<Student>();
           studentList = GetStudentList();
           foreach(var student in studentList)
            {
    		    var db = UmbracoContext.Application.DatabaseContext.Database;
    		    var insert = new Sql("INSERT INTO students VALUES('" + StudentID + "', '" + StudentName +"'. '" + Email +"' )");
    		    int res = db.Execute(insert);
            }
    	}
    }
