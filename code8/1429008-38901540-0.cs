        public class CounterHolder
        {
            public int count = 0;
        }
        public class Gameplay
        {
            public static CounterHolder counterHolder = new CounterHolder();
            AClass aClass = new AClass(counterHolder);
            public void DoSomething()
            {
                // Something
                counterHolder.count++;
                aClass.printCount();
            }
        }
        public class AClass
        {
            private CounterHolder _counterHolder;
            public AClass(CounterHolder counterHolder)
            {
                _counterHolder = counterHolder;
            }
            public void printCount()
            {
                Console.WriteLine(_counterHolder.count.ToString());
            }
        }
