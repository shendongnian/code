      static void Main(string[] args)
            {
                var service = new DispatchTasksOnMachinesService(8, 3);
                service.DispatchTasks();
                Console.Read();
            }
    
            class DispatchTasksOnMachinesService
            {
                int numOfMachines;
                int tasksPerMachine;
                [ThreadStatic]
                private Random random = new Random();
    
                public DispatchTasksOnMachinesService(int numOfMachines, int tasksPerMachine)
                {
                    this.numOfMachines = numOfMachines;
                    this.tasksPerMachine = tasksPerMachine;
                }
    
                public async void DispatchTasks()
                {
                    var tasks = new List<Task<Tuple<Guid, Machine, int>>>();
                    for (int i = 0; i < this.numOfMachines; i++)
                    {
                        var j = i;
                        for (int k = 0; k < this.tasksPerMachine; k++)
                        {
                            var task = Task.Run(() => Foo(Guid.NewGuid(), new Machine("machine" + j)));
                            tasks.Add(task);
                        }
                    }
    
                    var results = await Task.WhenAll<Tuple<Guid, Machine, int>>(tasks);
                    foreach (var result in results)
                    {
                        Console.WriteLine($"Task {result.Item1} on  {result.Item2} yielded result {result.Item3}");
                    }
                }
    
                private Tuple<Guid, Machine, int> Foo(Guid taskId, Machine machine)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(random.Next(1,5)));
                    Console.WriteLine($"Task {taskId} has completed on {machine}");
                    return new Tuple<Guid, Machine, int>(taskId, machine, random.Next(500, 2000));
                }
            }
    
            class Machine
            {
                public string Name { get; private set; }
    
                public Machine(string name)
                {
                    this.Name = name;
                }
    
                public override string ToString()
                {
                    return this.Name;
                }
            }
