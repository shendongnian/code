    1. ((IDisposable)CreateDeferredIEnumerable(...)).Dispose();
    1. ((IDisposable)CreateDeferredIEnumerable(...).GetEnumerator()).Dispose();
    2. CreateDeferredIEnumerable(...).ToList();
    3. CreateDeferredIEnumerable(...).Take(1).ToList();
    4. foreach (var x in CreateDeferredIEnumerable(...)) break;
