    static void Main(string[] args)
    {
        UnityContainer unityContainer = new UnityContainer();
        unityContainer.RegisterType<Employee>();
        
        unityContainer.RegisterType<ISalaryCalculation, BossSalaryCalculation>("Boss");
        unityContainer.RegisterType<ISalaryCalculation, NormalSalaryCalculation>("Normal");
        var employee = unityContainer.Resolve<Employee>(new ParameterOverride("salaryCalculationCalculator", new ResolvedParameter<ISalaryCalculation>("Boss")));
        Console.WriteLine(employee.CalcSalary());
    }
