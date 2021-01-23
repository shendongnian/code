    using System;
    
    class BizarreCollection
    {
        public Enumerator GetEnumerator()
        {
            return new Enumerator();
        }
        
        public class Enumerator
        {
            private int index = 0;
            
            public bool MoveNext()
            {
                if (index == 10)
                {
                    return false;
                }
                index++;
                return true;
            }
            
            public int Current { get { return index; } }
        }
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            foreach (var item in new BizarreCollection())
            {
                Console.WriteLine(item);
            }
        }
    }
