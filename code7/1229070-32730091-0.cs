    class BoxedT
    {
        T t;
        public BoxedT(T value) { t = value; }
        public static implicit operator T(BoxedT boxed) { return boxed.t; }
    }
