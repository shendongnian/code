    public class EnclosingType<T>
        where T : BaseEntity
    {
        internal IDictionary<string, T> FillObjects(
             IReadableRange<T> svc,
             Func<T, string> getKey)
        {
        }
    }
