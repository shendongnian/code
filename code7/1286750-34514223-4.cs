        internal class Disposer : Component
        {
            private Action<bool> dispose_;
     
            internal Disposer(Action<bool> disposeCallback)
            {
                this.dispose_ = disposeCallback;
            }
     
            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
     
                this.dispose_(disposing);
            }
        }
 
