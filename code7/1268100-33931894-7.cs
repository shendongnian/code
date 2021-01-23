    public interface IEmployee
    {
        void Register(string role);
    }
    
    public abstract class Employee : IEmployee
    {
        public void Register(string role)
        {
            Console.WriteLine(role);
        }
    }
    
    // Case 2
    public class Developer : Employee, IEmployee
    {
        // this will not work without IEmployee in declaration!
    	void IEmployee.Register(string role)
        {
            Console.WriteLine("i'm developer!");
        }
    }
