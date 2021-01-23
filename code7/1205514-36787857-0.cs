	// this is the main collection that will be persisted, mark it as protected
	protected virtual ICollection<Employee> EmployeesInternal { get; private set; } = new List<Employee>();
	
	// this will expose collection contents to public, seemingly unneccessary `Skip` statement will prevent casting back to Collection
	public IEnumerable<Employee> Employees => EmployeesInternal.Skip(0);
	// this is property accessor that will be used to define model and/or in `Include` statements, could be marked as internal if your domain/persistance/services are in the same assembly
	public static Expression<Func<Organization, ICollection<Employee>>> EmployeeAccessor = f => f.EmployeesInternal;
	
