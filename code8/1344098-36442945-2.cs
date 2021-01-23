    public class EmployeeRepository : Repository<Employee>
    {
    
        public EmployeeRepository(DbContext context) : base(context) {
           
        }
        public override Employee Find(Expression<Func<TEntity, bool>> match)
        {
            // You can either use the base class method or implement your custom logic
        }
     
     	//This is where you encapsulate your business logic
    	 public Employee FindSpecific(Nullable<decimal> employeeNum, string employeeName){
    		 return context.SEARCHEMPLOYEE(employeeNum, employeeName);
    	 }
    }
