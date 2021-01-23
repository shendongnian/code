    public partial class Student
    {
    	public int StudentId { get; set; }
    	public int CourseId { get; set; }
    	public string Name { get; set; }
    	public string Status { get; set; }
    	public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
    
    public partial class Grade
    {
    	public int GradeId { get; set; }
    	public string Value { get; set; }
    	public string Status { get; set; }
    	public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
    
    public class StudentGrade
    {
    	public int StudentId { get; set; }
    	public int GradeId { get; set; }
    	public virtual Student Student { get; set; }
    	public virtual Grade Grade { get; set; }
    }
