        public void AddNewEmployee(Employee employee){
            this.Employees.Add(employee);			
            			
            this.IsAllEmpEngaged = this.IsAllEmpEngaged && employee.IsEngagedwithWork 
         }
