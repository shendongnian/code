    class A_Impl<T> : IA<T> {
        T data;
        public void Method(IB<TInput> entities) {
            entities.MethodB(data);
        }
    }
