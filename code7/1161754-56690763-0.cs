csharp
[QueueTypeAttribute(QueueProviderType.InProcess)] // exports IQueueProviderPlugin<>
public class InProcessQueuePlugin<T> : IQueueProviderPlugin<T>
{
    readonly Queue<T> _queue = new Queue<T>();
    public T Dequeue() => _queue.Dequeue();
    public void Enqueue(T item)
    {
        _queue.Enqueue(item);
    }
}
