        static Action<IEnumerable<string>> aSetter;
        static Func<IEnumerable<string>> aGetter;
        public static IEnumerable<string> WhateverB
        {
            get
            {
                 if (aGetter != null)
                 {
                     return aGetter();
                 }
            }
            set
            {
                 if (aSetter != null)
                 {
                     aSetter(value);
                 }
            }
        }
    }
