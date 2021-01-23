    static void Main(string[] args)
    {
        UnityContainer unityContainer = new UnityContainer();
        unityContainer.RegisterType<Employee>();
        
        if (someCondition)
        {
            unityContainer.RegisterType<ISalaryCalculation, BossSalaryCalculation>("Boss");
        }
        else
        {
            unityContainer.RegisterType<ISalaryCalculation, NormalSalaryCalculation>("Normal");
        }
        var employee = unityContainer.Resolve<Employee>();
        Console.WriteLine(employee.CalcSalary());
    }
