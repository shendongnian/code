    class RefCounted
    {
        private static readonly HashSet<RefCounted> _alive = new HashSet<RefCounted>();
        private int _referenceCount;
        public RefCounted()
        {
            AddRef();
        }
        public AddRef()
        {
            if (_referenceCount == 0)
            {
                // the collection ensures a strong reference to the object, to prevent
                // the object from being garbage-collected even if the only other
                // references are weak references.
                _alive.Add(this);
            }
            _referenceCount++;
        }
        public Release()
        {
            if (--_referenceCount)
            {
                // no longer need to force the object to stay alive; if the only remaining
                // references to the object are weak references, then the garbage
                // collector may collect the object.
                _alive.Remove(this);
            }
        }
    }
