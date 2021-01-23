    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class StubSequenceBuilder<T0>
    {
        private readonly Queue<Func<T0>> _sequenceQueue = new Queue<Func<T0>>();
        public StubSequenceBuilder<T0> Next(Func<T0> func)
        {
            _sequenceQueue.Enqueue(func);
            return this;
        }
    
        //...
    }
    
    public class StubSequenceBuilder<T0, T1>
    {
        private readonly Queue<Func<T0, T1>> _sequenceQueue = new Queue<Func<T0, T1>>();
        public StubSequenceBuilder<T0, T1> Next(Func<T0, T1> func)
        {
            _sequenceQueue.Enqueue(func);
            return this;
        }
    
        //...
    }
    //...
