    void Main()
    {
    	var filterField = "Id";
    	List<int> Ids = new List<int>();
    	var eParam = Expression.Parameter(typeof(EmployeeDetail), "e");
    	var method = Ids.GetType().GetMethod("Contains");
    	var call = Expression.Call(Expression.Constant(Ids), method, Expression.Property(eParam, filterField));
    	var lambda = Expression.Lambda<Func<EmployeeDetail, bool>>(call, eParam);
    }
    
    public class EmployeeDetail
    {
    	public int Id { get; set; }
    }
