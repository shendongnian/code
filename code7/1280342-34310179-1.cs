       // Dedicated object to lock for this property only
       private object myPropSync = new object();
       private T _myPropVal;
       public IEnumerable<T> MyProp
        {
            get
            {
                // Check if property is null
                if(_myPropVal== null)
                {
                    // If null -> make sure you are the only one in the next section
                    lock (myPropSync) {
                        // Re-test, because another thread can 
                        // set the property while waiting for the lock
                        if (_myPropVal== null) {
                             this.SetProp();
                        }
                    }
                }    
                return this._myPropVal;
            }    
            private set {
              lock (_myPropSync) {
                 _myPropVal = value;
              }
            }
        }
