       // Dedicated object to lock for this property only
       private object myPropSync = new object();
       public IEnumerable<T> MyProp
        {
            get
            {
                // Check if property is null
                if(MyProp == null)
                {
                    // If null -> make sure you are the only one in the next section
                    lock (myPropSync) {
                        // Re-test, because another thread can 
                        // set the property while waiting for the lock
                        if (MyProp == null) {
                             this.SetProp();
                        }
                    }
                }    
                return this.MyProp;
            }    
            private set; 
        }
