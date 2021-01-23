    public class Family{
        public string ChildName { get; set; }
    }
    public class Employee{
        public int Id { get; set; }
        public string Name { get; set; }
        public Family Child { get; set; }
	
	    public Employee(){
		    Child = new Family();
	    }
    }
    Employee emp = new Employee();
    emp.Family.ChildName = "Nested calss attribute value";
