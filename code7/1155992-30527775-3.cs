	class Scheduler{
		IDDPSchedulerTaskFactory _taskFactory;
		public Scheduler(IDDPSchedulerTaskFactory taskFactory){
			_taskFactory = taskFactory; // factory gets all the needed dependencies for all tasks from DI
		}	
		...
		
		public void ConfigureTasks(){
			_tasks.Add(_taskFactory.CreateNormal());
			_tasks.Add(_taskFactory.CreateSpecial("Some important message"));
            _tasks.Add(_taskFactory.CreateTaskWithDifferentDependenties(123));
		}
	}
