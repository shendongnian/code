    //you will call this method, which is going to call the SelectByCriteriaBase
    public  List<StudentDto> SelectByName(CriteriaStudentModel criteria)
    {
      var query = SelectByCriteriaBase(criteria);  //return you the query which was 
                                                   //created by LINQ
      var dtos = query.Select(x=>x. new StudentDto
      {
         UserId = x.UserId,     //and put your data to a dto
         UserName = x.UserName,
         Completions = x.Completions
       }).ToList();
     return dtos;                          //after you can work with dto as you want
    }
    public IQuerable<StudentModel> SelectByCriteriaBase(CriteriaStudentModel criteria)
    {
         var query = Query<StudentModel>();
         if(criteria.UserName !="")
         {
           query = query.Where(x=>x.UserName.Contains(criteria.UserName))
         }
         //here you can add more "if" sectors to organize better your code.
        return query; 
     }
    public class StudentDto//DTO class which "holds" your data after inserting there
    {                   //result from query
      public int UserId {get:set;}
      public string UserName {get:set;}
      public virtual ICollection<Completion> Completions { get; set; }
    }
