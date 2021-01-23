    public abstract class Foo<T> where T : Bar {
        public virtual Bar Do(Bar obj) {
            return null;
        }
        protected abstract Bar Do(T obj);
    }
