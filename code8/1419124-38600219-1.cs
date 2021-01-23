    WeakReference<RefCounted> o = new WeakReference<RefCounted>(new RefCounted());
    RefCounted r;
    if (o.TryGetTarget(out r))
    {
        // do stuff with r
        // done with the object? Then call:
        r.Release();
    }
