    public class Student
    {
        public int Id { get; set; }
        public double? Cosine { get; set; }
    }
    
    public List<student> GetStuCosineSimilarity()
    { 
        List<Student> lst = new List<Student>();
 
        lst = (from s in DB.Students
               select new Student()
               {
                   Id = s.StudentId,
                   Cosine = s.cosineSimilarity
               }).ToList();
 
        lst = lst.OrderBy(k => k.Cosine).ToList(); // Sorting the float value
        return lst;
    }
