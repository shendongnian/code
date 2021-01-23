    // TODO: Implement interfaces if you want
    public class ImmutableRectangularList<T>
    {
        private readonly int Width { get; }
        private readonly int Height { get; }
        private readonly IImmutableList<T> list;
        public ImmutableRectangularList(IImmutableList<T> list, int width, int height)
        {
            // TODO: Validation of list != null, height >= 0, width >= 0
            if (list.Count != width * height)
            {
                throw new ArgumentException("...");
            }
            Width = width;
            Height = height;
            this.list = list;
        }
        public T this[int x, int y]
        {
            get
            {
                if (x < 0 || x >= width)
                {
                    throw new ArgumentOutOfRangeException(...);
                }
                if (y < 0 || y >= height)
                {
                    throw new ArgumentOutOfRangeException(...);
                }
                return list[y * width + x];
            }
        }
    }
