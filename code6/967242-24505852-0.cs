    private void InitialiseJobs(IScheduler scheduler)
    {
        var classname = "Proto.QuartzScheduler.Domain.Jobs.ExampleJob";
        Type genericTypeParameter = Type.GetType(classname);
        Type genericClass = typeof(JobSetup<>);
        Type constructedClass = genericClass.MakeGenericType(genericTypeParameter);
        var setup = Activator.CreateInstance(constructedClass) as IJobSetup;
        setup.Run(20);
    }
