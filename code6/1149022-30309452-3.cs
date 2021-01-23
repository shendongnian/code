    public interface IContentReference<out T> where T : IReferable
    {
        string Name { get; }
    }
    public class ContentReference<T> : IContentReference<T> where T : IReferable
    {
        public string Name { get; private set; }
        public ContentReference(T value)
        {
            this.Name = value.Name;
        }
        public static implicit operator ContentReference<T>(T value)
        {
            return new ContentReference<T>(value);
        }
    }
