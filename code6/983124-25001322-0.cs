        class Department
        {
            public Department() {}
            public Department(int departmentId, string departmentName)
            {
                DepartmentId = departmentId;
                DepartmentName = departmentName;
            }
            public int DepartmentId { get; set; }
            public string DepartmentName { get; set; }
        }
        class Worker 
        {
            public Worker() {}
            public Worker(int workerId, string workerName, Department department)
            {
                WorkerId = workerId;
                WorkerName = workerName;
                Dept = department;
            }
            public Worker(int workerId, string workerName, int departmentId, string departmentName)
               : this(workerId, workerName, new Department(departmentId, departmentName)) {}
            public int WorkerId { get; set; }
            public string WorkerName { get; set; }
            public Department Dept { get; set; }
    
        }
