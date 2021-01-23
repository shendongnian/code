	int nTotalTasks=10;
	string param1="test";
	string param2="test";
  
	IDisposable subscription =
		Observable
			.Range(0, 1000)
			.Select(i => Observable.FromAsync(() => Task.Factory.StartNew<bool>(() =>
			{
				MyClass cls = new MyClass();
				bool bRet = cls.Method1(param1, param2, i); // takes up to 2 minutes to finish
				return bRet;
			})))
			.Merge(nTotalTasks)
			.ToArray()
			.Subscribe((bool[] results) =>
			{
				/* Do something with the results. */
			});
