    public abstract class BaseItem
    {
        public abstract string Path { get; }
        public Uri Uri
        {
            get
            {
                return new Uri(string.Format("pack://application:,,,/{0};component/{1}",
                    this.GetType().Assembly.FullName, Path));
            }
        }
    }
