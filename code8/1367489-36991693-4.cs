	public void DoSomeTask()
	{
		if (this.lastTask == null)
			this.lastTask = (Task) Task.FromResult<bool>(false);
		// ISSUE: method pointer
		// ISSUE: method pointer
		this.lastTask = this.lastTask
		.ContinueWith(
			Program.<>c.<>9__2_0
			?? (Program.<>c.<>9__2_0 = new Action<Task>((object) Program.<>c.<>9, __methodptr(<DoSomeTask>b__2_0))))
		.ContinueWith<Task>(
			Program.<>c.<>9__2_1
			?? (Program.<>c.<>9__2_1 = new Func<Task, Task>((object) Program.<>c.<>9, __methodptr(<DoSomeTask>b__2_1))))
		.Unwrap();
	}
	[CompilerGenerated]
	[Serializable]
	private sealed class <>c
	{
		public static readonly Program.<>c <>9;
		public static Action<Task> <>9__2_0;
		public static Func<Task, Task> <>9__2_1;
		static <>c()
		{
			Program.<>c.<>9 = new Program.<>c();
		}
		public <>c()
		{
			base.\u002Ector();
		}
		internal void <DoSomeTask>b__2_0(Task t)
		{
		}
		internal Task <DoSomeTask>b__2_1(Task t)
		{
			return Task.Delay(250);
		}
	}
