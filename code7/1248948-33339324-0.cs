    class OutWrap<T,U> where T : U
    {
        private readonly SomeObject<T> obj;
        public OutWrap(SomeObject<T> obj)
        {
            this.obj = obj;
        }
        public T Value
        {
            get
            {
                T t;
                obj.GetData(out t);
                return t;
            }
        }
    }
