	public class Employee : IEmployee
	{
		public JobCollection Jobs { get; set; }
		public Employee()
		{
			Jobs = new JobCollection();
		}
	}
	
	public class JobCollection : ObservableCollection<Job>
	{
	
	}
