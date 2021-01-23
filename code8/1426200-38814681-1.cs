    public class ClassB
    {
        static ClassA a;
        public static IEnumerable<string> WhateverB
        {
            get { return a.WhateverA; }
            set { a.WhateverA = value; }
        }
    }
