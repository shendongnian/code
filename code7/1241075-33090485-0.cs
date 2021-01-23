    .
    .
    var TotalEmployees = 1000;
    var list = new List<Employee>();
    FillList();
    public void FillList(int totalEmployees)
    {
       var rnd = new Random();
       for (int i = 1; i <= totalEmployees; i++)
       {
         list.Add(new Employee
         {
           Id = i + 1000,
           FirstName = "fName " + i,
           LastName = "lName " + i,
           AddDate = DateTime.Now.AddYears(-rnd.Next(1, 10)),
           Salary = rnd.Next(400, 3000),
           Projects = CreateRandomProjects()
         });
        }
      }
    }
    
    public static IList<Employee> EmployeesForPage(int page,int count)
        {
            var skipe = page * count;
            ViewBag.TotalPages = TotalEmployees/count;
            return list.Skip(skipe).Take(count).ToList();
        }
