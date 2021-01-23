    object syncObject = new object();
    Monitor.Enter(syncObject);
    try {
    	// Code updating shared data
    }
    finally {
    	Monitor.Exit(syncObject);
    }
    
    object syncObject = new object();
    lock (syncObject) {
    // Code updating shared data
    }
