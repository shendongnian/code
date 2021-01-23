    ConditionalWeakTable<object, ReaderWriterLockSlim> _locks;
    if (ResourceStore.Exists("resourceID")) {
        var rc = ResourceStore.GetResource("resourceID");
        var lck = _locks.GetValue(rc, () => new ReaderWriterLockSlim());
        lck.EnterReadLock();
        // Use the resource here
        lck.ExitReadLock();
    }
