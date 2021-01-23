    public class ClassA
    {
        private static IEnumerable<string> _whateverA;
        public static IEnumerable<string> WhateverA
        {
            get { return _whateverA; }
            set
            {
                _whateverA = value;
                // property changed, send message
                Messenger.Default.Send(new MyMessage(value));
            }
        }
    }
    public class ClassB
    {
        public ClassB()
        {
            // receive message
            Messenger.Default.Register<MyMessage>(this, message => 
            {
                WhateverB = message.Value;
                Console.WriteLine(string.Join(" ", WhateverB));
            });
        }
        public static IEnumerable<string> WhateverB { get; set; }
    }
