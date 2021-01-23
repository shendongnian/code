    void Main()
    {
        Func<Employee, Employee> getEmployeesBoss = (Employee employee) => {return employee.Boss;};
        //This works as it expects a Person to be returned and employee.Boss is a person.
    	Func<Employee, Person> getEmployeesBoss1 = getEmployeesBoss;
        //This fails as I could pass a non Employee person to this func which would not work.
    	Func<Person, Employee> getEmployeesBoss2 = getEmployeesBoss;
    }
    
    class Person {}	
    class Employee : Person { public Employee Boss{get;set;}	}
