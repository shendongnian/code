    public class MyServiceClass
    {
        [WebMethod]
        public Employee[] GetEmployessXML()
        {
            Employee[] emps = new Employee[] {
            new Employee()
            {
                Id=101,
                Name="Nitin",
                Salary=10000
            },
            new Employee()
            {
                Id=102,
                Name="Dinesh",
                Salary=100000
            }
            };
            return emps;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetEmployessJSON()
        {
            Employee[] emps = new Employee[] {
            new Employee()
            {
                Id=101,
                Name="Nitin",
                Salary=10000
            },
            new Employee()
            {
                Id=102,
                Name="Dinesh",
                Salary=100000
            }
            };
            return new JavaScriptSerializer().Serialize(emps);
        }
    }
