    public class Ref<T>
    {
        private T _ref;
        private IList<T> list;
        private int index;
        public Ref(T _ref)
        {
            this._ref = _ref;
        }
        public Ref(IList<T> list, int index)
        {
            this.list = list;
            this.index = index;
        }
        public void set(T _ref)
        {
            if (this._ref == null)
            {
                this.list[index] = _ref;
            }
            else
            {
                this._ref = _ref;
            }
        }
        public T get()
        {
            if (this._ref == null)
            {
                return this.list[index];
            }
            else
            {
                return this._ref;
            }
        }
    }
