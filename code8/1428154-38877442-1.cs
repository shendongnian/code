    public override List<object> InitializeDependencies() {
      var tasks = new[] { 
        Task.Run<object>(()=>new CustomerPresenter()),
        Task.Run<object>(()=>new EmployeePresenter()),
        Task.Run<object>(()=>new SalaryPresenter())
      };
      return tasks.Select(x=>x.Result).ToList();
    }
