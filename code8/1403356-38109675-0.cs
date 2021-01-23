    public class Employee
    {
    	public Employee(int id, object date, object time)
    	{
    		Id = id;
    		DateTime = DateTime.Parse(string.Format("{0} {1}", date, time))
    	}
    
    	public int Id { get; protected set; }
    	public DateTime DateTime  { get; protected set; }
    }
