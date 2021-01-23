	public override List<object> InitializeDependencies()
	{
		var tasks = new[] 
		{ 
			Task.Factory.StartNew<object>(()=>new CustomerPresenter()),
			Task.Factory.StartNew<object>(()=>new EmployeePresenter()),
			Task.Factory.StartNew<object>(()=>new SalaryPresenter()),
		};
		
		Task.WaitAll(tasks);
		
		return tasks.Select(x=>x.Result).ToList();
	}
