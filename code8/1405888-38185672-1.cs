	public void doSomething(object obj) {
	   // do something.
	}
	public void Run() {
		var collection = new BlockingCollection<object>();
		
		// Start workers
		for (int i = 0; i < 5; i++) {
			new MyConsumer<object>(collection, doSomethingOnAsset);
		}
		
		// Create object to consume
		for (int i = 0; i < 100; i++) {
			collection.Add(new object());
		}
	}
