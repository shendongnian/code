    void Main()
    {
    	var obj = new BackgroundWorker();
    	obj.DoWork += OnSomeEvent;
    	var oc = new ObservableCollection<object>{ obj };
    	
    	WeakReference objRef = new WeakReference(obj);
    	Console.WriteLine(objRef.IsAlive);
    	
    	oc.Remove(obj);
    	obj = null;
    	GC.Collect();
    	
    	Console.WriteLine(objRef.IsAlive);
    }
    
    private void OnSomeEvent(object sender, DoWorkEventArgs e)
    {   
        Console.WriteLine("work");
    }
