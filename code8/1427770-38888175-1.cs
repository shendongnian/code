    using (Repo db = new Repo(sessionFactory))
    {
        Job job = new Job() { Description = "A very important job" };
        Employee empl = new Employee() { Name = "John Smith" };
        Task task = new Task() { Job = job, Assignee = empl };
        db.Save(job);
        db.Save(empl);
        empl.Tasks.Add(task);
        db.Save(task);
        IList<Job> jobs;
        jobs = db.GetList<Job>();
        IList<Employee> employees;
        employees = db.GetList<Employee>();
        jobs[0].Description = "A totally unimportant job";
        Console.WriteLine(employees[0].Tasks[0].Job.Description);
    }
