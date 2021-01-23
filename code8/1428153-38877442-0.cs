    public override List<object> InitializeDependencies() {
      var tasks = new[] { 
        Task.Run(()=>new CustomerPresenter()),
        Task.Run(()=>new EmployeePresenter()),
        Task.Run(()=>new SalaryPresenter())
      };
      return tasks.Select(x=>x.Result).ToList();
    }
