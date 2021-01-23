    if (!Api.IsLoggedIn) {
    	var rwl = new ReaderWriterLock ();
    	rwl.AcquireReaderLock (int.MaxValue);
    	try {
    		if (!Api.IsLoggedIn) {					
    			LockCookie lc = rwl.UpgradeToWriterLock (timeOut);
    			try {
    				Api.Login();
    			} finally {
    				// Ensure that the lock is released.
    				rwl.DowngradeFromWriterLock (ref lc);
    			}
    		}
    	} finally {
    		// Ensure that the lock is released.
    		rwl.ReleaseReaderLock ();
    	}
    }
