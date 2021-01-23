    class WeakGUIObject : IGUIObject
    {
        WeakReference wr;
    
        public WindowsFormsControl( IGUIObject inner )
        {
            wr = new WR(inner);
        }
    
        public virtual Rectangle Bounds
        {
            get
            {
                var inner = wr.Target;
                if (inner == null) throw ObjectDisposedException();
                return inner.Bounds;
            }
        }
    }
