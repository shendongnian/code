    int idleTime = 1000;
    
    var mouseMoving =
    	Observable
    	.Buffer(								 // Buffer the mouse move events for the duration of the idle time.
    		mouseMove,
    		TimeSpan.FromMilliseconds(idleTime))
    	.Select(x => x.Any())                    // Return true if the buffer is not empty, false otherwise.
    	.DistinctUntilChanged()                  // Only notify when the mouse moving state changes.
    	.Dump();
