    class CreateEnumerable_Enumerator : IEnumerator<int> {
    	// local variables are promoted to instance fields
        private int i;
        private Disposable d;
    	
    	// implementation of Current
        private int current;
        public int Current => current;
        object IEnumerator.Current => current;
    
    	// State machine
        enum State { Before, Running, Suspended, After };
        private State state = State.Before;
    
    	// Section 10.14.4.1
        public bool MoveNext() {
            switch (state) {
                case State.Before: {
                        state = State.Running;
                        // begin iterator block
                        i = 0;
                        d = new Disposable();
                        i = i + 1;
                        // yield return occurs here
                        current = i;
                        state = State.Suspended;
                        return true;
                    }
                case State.Running: return false; // can't happen
                case State.Suspended: {
                        state = State.Running;
                        // goto repeat
                        i = i + 1;
                        // yield return occurs here
                        current = i;
                        state = State.Suspended;
                        return true;
                    }
                case State.After: return false; 
                default: return false;  // can't happen
            }
        }
    
    	// Section 10.14.4.3
        public void Dispose() {
            switch (state) {
                case State.Before: state = State.After; break;
                case State.Running: break; // unspecified
                case State.Suspended: {
                        state = State.Running;
                        // finally occurs here
                        d.Dispose();
                        state = State.After;
                    }
                    break;
                case State.After: return;
                default: return;    // can't happen
            }
        }
    
        public void Reset() { throw new NotImplementedException(); }
    }
    class CreateEnumerable_Enumerable : IEnumerable<int> {
      public IEnumerator<int> GetEnumerator() {
        return new CreateEnumerable_Enumerator();
      }
      
      IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
      }
    }
    IEnumerable<int> CreateEnumerable() {
      return new CreateEnumerable_Enumerable();
    }
   
