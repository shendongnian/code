     public bool IsAllEmpEngaged { 
       get {
           return (Employees != null) && 
                       Employees.All(e => e.IsEngagedwithWork)
       }
    }
