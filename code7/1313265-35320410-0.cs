    public class EmployeesDTO
    {
       public int Id{get;set;}
       public string fName {get;set;}
       //the rest
    }
 
    var query= db.EMployees.Where(x=>x.lname=="marcus")
                           .Select(d=>new EmployeesDTO{Id=d.Id, fName=d.Name,...});
