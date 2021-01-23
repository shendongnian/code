	private async void Foo()
	{
	    string[] files = GetFilesFromDir(@"C:\Bar\");
	    if (files == null || files.Length < 0) { return; }
	
	    for(int i = 0; i < files.Length; i++)
	    {
		    tbSked.Text = files[i];
		    Task t1 = Task.Factory.StartNew(()=>LoadFile());
		    t1.ContinueWith((a) => SQLUpdate());
		    var continuationTask = t1.ContinueWith((b) => RestartTimer());
		    await continuationTask;
	    }
	}
