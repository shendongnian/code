    bool __lockWasTaken = false;
    try {
    	System.Threading.Monitor.Enter(x, ref __lockWasTaken);
    	...
    }
    finally {
    	if (__lockWasTaken) System.Threading.Monitor.Exit(x);
    }
