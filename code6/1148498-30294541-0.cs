    public class EmployeeFinder : IFinder<Employee>
    {
    	public IEnumerable<Employee> GetData(DataStore dataStore)
    	{
    		return dataStore.Employees;
    	}
    }
