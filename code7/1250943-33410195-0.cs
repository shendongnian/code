    using (var context = new EmployeeContext())
            {
                var employee = context.Employees.Where(x=> x.Age > 20);
                foreach( var item in employee)
                {
                    context.Entry(item).Reference(x => x.ContactDetails).Load();
                    context.Entry(item).Reference(x => x.EmpDepartment).Load();
                    context.Entry(item.EmpDepartment).Collection(x => x.DepartmentProjects).Load();
                }
            };
