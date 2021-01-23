    class A 
    {
    	public void Execute<T>() { }
    	public void Execute(string[] args) { }
    }
	var method = typeof(A).GetMethods().FirstOrDefault(
		m => m.Name == "Execute" 
		&& !m.GetParameters().Any()
		&& m.GetGenericArguments().Count() == 1
		);
	
	Type barType = Type.GetType("Program.Bar");
	
	method.MakeGenericMethod(barType).Invoke();
