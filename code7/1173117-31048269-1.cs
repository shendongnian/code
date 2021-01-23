	var tasks = new List<Task> {t1, t2, t3};
	Action<Task> handler = null;
	handler = (Task t) =>
	{
		if (t.IsFauled) {
			tasks.Remove(t);
			Task.Factory.ContinueWhenAny(tasks.ToArray, handler);
		} else {
			Console.WriteLine(t.Result);
		}
	};
	Task.Factory.ContinueWhenAny(tasks.ToArray, handler);
