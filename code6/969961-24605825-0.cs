    using System;
    using System.Threading;
    using ExitGames.Concurrency.Fibers;
    
        public class EntityFiberManager
        {
            readonly object _executionLock = new object();
            //readonly object _enqueueLock = new object();
            readonly IFiber _applicationFiber;
            IFiber _currentFiber;
            volatile Action _actions;
    
            public EntityFiberManager(IFiber applicaitonFiber)
            {
                _currentFiber = _applicationFiber = applicaitonFiber;
            }
    
            /// <summary>
            /// Removes the current set fiber if it's equal to <paramref name="fiber"/>.
            /// All queued actions will be rerouted to the application fiber.
            /// Can be called from anywhere.
            /// Disposed fiber should never be set with <see cref="AcquireForNewFiber"/> again.
            /// Doesn't block.
            /// </summary>
            public void ReleaseForDisposedFiber(IFiber fiber)
            {
                if (fiber == null) throw new ArgumentNullException("fiber");
                ReleaseForDisposedFiberInternal(fiber);
            }
    
            private void ReleaseForDisposedFiberInternal(IFiber fiber)
            {
                if ((_executingEntityFiberManager != null && _executingEntityFiberManager != this) || !Monitor.TryEnter(_executionLock, 1))
                {
                    _applicationFiber.Enqueue(() => ReleaseForDisposedFiberInternal(fiber));
                    return;
                }
                try
                {
                    //lock (_enqueueLock)
                    //{
                    if (_currentFiber != fiber) return;
                    _currentFiber = null;
                    Thread.MemoryBarrier(); // do not reorder!
                    if (_actions != null)
                        _applicationFiber.Enqueue(() => Execute(null));
                    //}
                }
                finally
                {
                    Monitor.Exit(_executionLock);
                }
            }
    
            /// <summary>
            /// Sets a new fiber. 
            /// All queued actions will be rerouted to that fiber.
            /// Can be called from anywhere except from another Executor queud action.
            /// Blocks until the current execution of queued actions is not finished.
            /// </summary>
            public void AcquireForNewFiber(IFiber fiber)
            {
                if (fiber == null) throw new ArgumentNullException("fiber");
                if (_executingEntityFiberManager != null && _executingEntityFiberManager != this) 
                    throw new InvalidOperationException("Can't call this method on from queued actions on another instance");
                lock (_executionLock)
                //lock (_enqueueLock)
                {
                    if (_currentFiber == fiber) return;
                    var fiberLocal = _currentFiber = fiber;
                    Thread.MemoryBarrier(); // do not reorder!
                    if (_actions != null)
                        fiberLocal.Enqueue(() => Execute(fiberLocal));
                }
            }
    
            /// <summary>
            /// Enqueus an action to the current fiber.
            /// Doesn't block.
            /// </summary>
            public void Enqeue(Action action)
            {
                if (action == null) throw new ArgumentNullException("action");
    
                //lock (_enqueueLock)
                //{
                // we could add another lock
                // but we just need to ensure
                // that we properly detect when previous queue was empty
    
                // also delegate are immutable so we exchange references
    
                Action currentActions;
                Action newActions;
                do
                {
                    Thread.Sleep(0);
                    currentActions = _actions;
                    newActions = currentActions + action;
                }
                while (Interlocked.CompareExchange(ref _actions, newActions, currentActions) != currentActions);
    
                bool start = currentActions == null;
    
                if (start)
                {
                    // that's why we would want to use _enqueueLock
                    // we don't want the current fiber to be replaced
                    // imagine that when replacing queue was empty
                    // than we read the fiber
                    var fiber = _currentFiber;
                    Thread.MemoryBarrier();
                    if (fiber == null)
                        fiber = _applicationFiber;
                    // and then replace writes its new fiber to memory
                    // we have a wrong fiber here
                    // and Execute will just quit
                    // and all next Enqueue calls will do nothing
                    // but now it's fixed with MemoryBarrier call. I think so.
                    fiber.Enqueue(() => Execute(fiber));
                }
                //}
            }
    
            [ThreadStatic]
            static EntityFiberManager _executingEntityFiberManager;
    
            void Execute(IFiber currentFiber)
            {
                lock (_executionLock)
                {
                    if (currentFiber != _currentFiber) return; // replaced
                    var actions = Interlocked.Exchange(ref _actions, null);
                    if (actions == null) return;
                    if (_executingEntityFiberManager != null)
                        throw new InvalidOperationException("Already in execution process");
                    _executingEntityFiberManager = this;
                    try
                    {
                        actions();
                    }
                    finally
                    {
                        _executingEntityFiberManager = null;
                    }
                }
            }
        }
    
