	public class SomeRandomClass {
		
		private object locker = new object();
		public void MethodA {
			lock(locker) {
				// exclusive club
                // do something before calling _methodB
				_methodB();
			}
		}
		private void _methodB {
			// do that, what used to be done by MethodB
		}
		public void MethodB {
            //this one only exists to expose _methodB in a thread-safe context
			lock(locker) {		
				_methodB();
			}
		}
	}
