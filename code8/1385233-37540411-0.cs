    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    public class FakeList : IEnumerable<int>, IEnumerable
    {
        private int one;
        private int two;
        [IteratorStateMachine(typeof(<GetEnumerator>d__2))]
        public IEnumerator<int> GetEnumerator()
        {
            yield return this.one;
            yield return this.two;
        }
        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();
        [CompilerGenerated]
        private sealed class <GetEnumerator>d__2 : IEnumerator<int>, IDisposable, IEnumerator
        {
            private int <>1__state;
            private int <>2__current;
            public FakeList <>4__this;
            [DebuggerHidden]
            public <GetEnumerator>d__2(int <>1__state)
            {
                this.<>1__state = <>1__state;
            }
            private bool MoveNext()
            {
                switch (this.<>1__state)
                {
                    case 0:
                        this.<>1__state = -1;
                        this.<>2__current = this.<>4__this.one;
                        this.<>1__state = 1;
                        return true;
                    case 1:
                        this.<>1__state = -1;
                        this.<>2__current = this.<>4__this.two;
                        this.<>1__state = 2;
                        return true;
                    case 2:
                        this.<>1__state = -1;
                        return false;
                }
                return false;
            }
            [DebuggerHidden]
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }
            [DebuggerHidden]
            void IDisposable.Dispose()
            {
            }
            int IEnumerator<int>.Current =>
                this.<>2__current;
            object IEnumerator.Current =>
                this.<>2__current;
        }
    }
