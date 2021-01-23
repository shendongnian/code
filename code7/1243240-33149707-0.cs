	public interface IPerson { }
	public interface IEmployee : IPerson { }
	public class Person : IPerson { }
	public class Employee : Person, IEmployee { }
	
