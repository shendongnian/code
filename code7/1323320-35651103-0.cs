    class CommandLineParameter<T> { }
    class CommandlineParameterCollection
    {
        // use most common type to store items in inner collection - object
        private readonly List<object> inner;
        public void Add<T>(CommandLineParameter<T> value)
        {
            inner.Add(value);
        }
        public void Remove<T>(CommandLineParameter<T> value)
        {
            inner.Remove(value);
        }
        public CommandLineParameter<T> GetAt<T>(int index)
        {
            // will thow InvalidCastException if T at given index doesn't match passed T
            return (CommandLineParameter<T>)inner[index];
        }
    }
