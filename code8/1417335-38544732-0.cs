    using System;
    namespace InjectionConsole
    {
        class Service1
        {
            public Service1(Service2 s2) {
                this.Service2 = s2;
            }
            private Service2 Service2 { get; set; }
            public void Say()
            {
                Console.WriteLine("Hello, I m Service 1, let me call Service 2");
                Service2.Say();
            }
        }
    }
