    public class ObjectWithReferences : IDisposable
    {
        private List<ObjectWithReferences> childs;
        protected readonly ObjectWithReferences Parent;
        public bool IsDisposed { get; private set; }
        protected ObjectWithReferences(ObjectWithReferences parent)
        {
            Parent = parent;
            if (parent != null)
            {
                parent.AddChild(this);
            }
        }
        private void AddChild(ObjectWithReferences child)
        {
            if (IsDisposed)
            {
                child.Dispose();
                return;
            }
            if (childs == null)
            {
                childs = new List<ObjectWithReferences>();
            }
            childs.Add(child);
        }
        private void DisposeChilds()
        {
            if (childs == null)
            {
                return;
            }
            foreach (ObjectWithReferences child in childs)
            {
                if (!child.IsDisposed)
                {
                    child.Dispose();
                }
            }
            childs = null;
        }
        public void Dispose()
        {
            if (!IsDisposed)
            {
                try
                {
                    Dispose(true);
                }
                finally
                {
                    try
                    {
                        DisposeChilds();
                    }
                    finally
                    {
                        IsDisposed = true;
                        GC.SuppressFinalize(this);
                    }
                }
            }
        }
        ~ObjectWithReferences()
        {
            if (!IsDisposed)
            {
                try
                {
                    Dispose(false);
                }
                finally
                {
                    try
                    {
                        DisposeChilds();
                    }
                    finally
                    {
                        IsDisposed = true;
                    }
                }
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            // Does nothing, not necessary to call!
        }
    }
