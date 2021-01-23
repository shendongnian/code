    public abstract class CoolBase<T> where T : class
    {
        private IEnumerable<T> somEnumerable;
        public void GetProperties()
        {
            foreach (var prop in typeof (T).GetProperties())
            {
                // do something with each property
            }
        }
    }
