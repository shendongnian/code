       [CLSCompliant(false)]
        public abstract class SolutionListener : IVsSolutionEvents, IVsSolutionEvents2, IVsSolutionEvents3, IVsSolutionEvents4, IDisposable
        {
            public IServiceProvider ServiceProvider { get; private set; }
    
            public IVsSolution Solution { get; private set; }
    
            private uint eventsCookie = (uint)ShellConstants.VSCOOKIE_NIL;
            private bool isDisposed;
            private static volatile object Mutex = new object();
    
            protected SolutionListener(IServiceProvider serviceProvider)
            {
                ServiceProvider = serviceProvider;
    
                Solution = serviceProvider.GetService(typeof(SVsSolution)) as IVsSolution;
                Debug.Assert(Solution != null, "Could not get the IVsSolution object");
                if (Solution == null)
                {
                    throw new InvalidOperationException();
                }
            }
    
            public abstract int OnAfterCloseSolution(object reserved);
            public abstract int OnAfterClosingChildren(IVsHierarchy hierarchy);
            public abstract int OnAfterLoadProject(IVsHierarchy stubHierarchy, IVsHierarchy realHierarchy);
            public abstract int OnAfterMergeSolution(object pUnkReserved);
            public abstract int OnAfterOpenProject(IVsHierarchy hierarchy, int added);
            public abstract int OnAfterOpenSolution(object pUnkReserved, int fNewSolution);
            public abstract int OnAfterOpeningChildren(IVsHierarchy hierarchy);
            public abstract int OnBeforeCloseProject(IVsHierarchy hierarchy, int removed);
            public abstract int OnBeforeCloseSolution(object pUnkReserved);
            public abstract int OnBeforeClosingChildren(IVsHierarchy hierarchy);
            public abstract int OnBeforeOpeningChildren(IVsHierarchy hierarchy);
            public abstract int OnBeforeUnloadProject(IVsHierarchy realHierarchy, IVsHierarchy rtubHierarchy);
            public abstract int OnQueryCloseProject(IVsHierarchy hierarchy, int removing, ref int cancel);
            public abstract int OnQueryCloseSolution(object pUnkReserved, ref int cancel);
            public abstract int OnQueryUnloadProject(IVsHierarchy pRealHierarchy, ref int cancel);
            public abstract int OnAfterAsynchOpenProject(IVsHierarchy hierarchy, int added);
            public abstract int OnAfterChangeProjectParent(IVsHierarchy hierarchy);
            public abstract int OnAfterRenameProject(IVsHierarchy hierarchy);
            public abstract int OnQueryChangeProjectParent(IVsHierarchy hierarchy, IVsHierarchy newParentHier, ref int cancel);
    
            public virtual void Initialize()
            {
                if (Solution != null && eventsCookie == (uint)ShellConstants.VSCOOKIE_NIL)
                {
                    ErrorHandler.ThrowOnFailure(Solution.AdviseSolutionEvents(this, out eventsCookie));
                }
            }
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
    
            protected virtual void Dispose(bool disposing)
            {
                if (!isDisposed)
                {
                    lock (Mutex)
                    {
                        if (disposing && Solution != null && eventsCookie != (uint)ShellConstants.VSCOOKIE_NIL)
                        {
                            ErrorHandler.ThrowOnFailure(Solution.UnadviseSolutionEvents((uint)eventsCookie));
                            eventsCookie = (uint)ShellConstants.VSCOOKIE_NIL;
                        }
                        isDisposed = true;
                    }
                }
            }
        }
