    public sealed class AsyncLockList {
        readonly Dictionary<object, SemaphoreReferenceCount> Semaphores = new Dictionary<object, SemaphoreReferenceCount>();
        SemaphoreSlim GetOrCreateSemaphore(object key) {
            lock (Semaphores) {
                if (Semaphores.TryGetValue(key, out var item)) {
                    item.IncrementCount();
                } else {
                    item = new SemaphoreReferenceCount();
                    Semaphores[key] = item;
                }
                return item.Semaphore;
            }
        }
        public IDisposable Lock(object key) {
            GetOrCreateSemaphore(key).Wait();
            return new Releaser(Semaphores, key);
        }
        public async Task<IDisposable> LockAsync(object key) {
            await GetOrCreateSemaphore(key).WaitAsync().ConfigureAwait(false);
            return new Releaser(Semaphores, key);
        }
        sealed class SemaphoreReferenceCount {
            public readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);
            public int Count { get; private set; } = 1;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void IncrementCount() => Count++;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void DecrementCount() => Count--;
        }
        sealed class Releaser : IDisposable {
            readonly Dictionary<object, SemaphoreReferenceCount> Semaphores;
            readonly object Key;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Releaser(Dictionary<object, SemaphoreReferenceCount> semaphores, object key) {
                Semaphores = semaphores;
                Key = key;
            }
            public void Dispose() {
                lock (Semaphores) {
                    var item = Semaphores[Key];
                    item.DecrementCount();
                    if (item.Count == 0)
                        Semaphores.Remove(Key);
                    item.Semaphore.Release();
                }
            }
        }
    }
