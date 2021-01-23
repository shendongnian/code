    internal class For<T, U> : IEnumerable<U>
    {
        private class ForEnumerator : IEnumerator<U>
        {
            private T current;
            private bool started;
            private Func<T, bool> finish;
            private Func<T, T> step;
            private Func<T, U> extract;
            public ForEnumerator(T obj, Func<T, U> extract, Func<T, bool> finish, Func<T, T> step)
            {
                this.current = obj;
                this.started = false;
                this.finish = finish;
                this.step = step;
                this.extract = extract;
            }
            U IEnumerator<U>.Current
            {
                get
                {
                    if (!started)
                        throw new InvalidOperationException("Internal error: enumeration was not started (call MoveNext)");
                    return extract(current);
                }
            }
            void IDisposable.Dispose()
            {
            }
            object System.Collections.IEnumerator.Current
            {
                get
                {
                    if (!started)
                        throw new InvalidOperationException("Internal error: enumeration was not started (call MoveNext)");
                    return extract(current);
                }
            }
            bool System.Collections.IEnumerator.MoveNext()
            {
                if (!started)
                    started = true;
                else
                    current = step(current);
                return finish(current);
            }
            void System.Collections.IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }
        }
        private T obj;
        private Func<T, bool> finish;
        private Func<T, T> step;
        private Func<T, U> extract;
        internal For(T obj, Func<T, U> extract, Func<T, bool> finish, Func<T, T> step)
        {
            this.obj = obj;
            this.finish = finish;
            this.step = step;
            this.extract = extract;
        }
        IEnumerator<U> IEnumerable<U>.GetEnumerator()
        {
            return new ForEnumerator(obj, extract, finish, step);
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new ForEnumerator(obj, extract, finish, step);
        }
    }
    public class ObjectHelper
    {
        public static IEnumerable<U> For<T, U>(this T obj, Func<T, U> extract, Func<T, bool> finish, Func<T, T> step) {
            return new For<T, U>(obj, extract, finish, step);
        }
    }
