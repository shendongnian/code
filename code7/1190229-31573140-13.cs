    using System;
    using System.Collections.Generic;
    namespace TestPubSub
    {
        public  class   Program
        {
            public  static  void    Main(string[] args)
            {
                Program.startListeners();
                Program.sendTestMessages();
                Program.stopConsoleFromExitingImmediately();
            }
            private static  void    startListeners()
            {
                SomeListener.Listen();
                SomeOtherListener1.Listen();
                SomeOtherListener2.Listen();
            }
            private static  void    sendTestMessages()
            {
                var publisher1  = new SomePublisher();
                var publisher2  = new SomeOtherPublisher();
                publisher1.DoSomethingCool("Hello world");
                publisher2.DoSomethingElse(DateTime.Now);
            }
            private static  void    stopConsoleFromExitingImmediately()
            {
                Console.ReadKey();
            }
        }
        public  static  class   PubSub<TMessage>
        {
            private static  List
                            <
                                Action
                                <
                                    TMessage
                                >
                            >                   listeners   = new List<Action<TMessage>>();
            public  static  void                Listen(Action<TMessage> listener)
            {
                if (listener != null)   listeners.Add(listener);
            }
            public  static  void                Unlisten(Action<TMessage> listener)
            {
                if (listeners.Contains(listener))   listeners.Remove(listener);
            }
            public  static  void                Broadcast(TMessage message)
            {
                foreach(var listener in listeners)  listener(message);
            }
        }
        public  class   SomeMessageType
        {
            public  int     SomeId;
            public  string  SomeDescription;
        }
        public  class   SomeOtherMessageType
        {
            public  DateTime    SomeDate;
            public  Double      SomeAmount;
        }
        public  class   SomePublisher
        {
            public  void    DoSomethingCool(string description)
            {
                var randomizer  = new Random();
                PubSub<SomeMessageType>.Broadcast(new SomeMessageType(){SomeId = randomizer.Next(), SomeDescription = description});
            }
        }
        public  class   SomeOtherPublisher
        {
            public  void    DoSomethingElse(DateTime when)
            {
                var randomizer  = new Random();
                PubSub<SomeOtherMessageType>.Broadcast(new SomeOtherMessageType(){SomeAmount = randomizer.NextDouble(), SomeDate = when});
            }
        }
        public  class   SomeListener
        {
            public  static  void    Listen()
            {
                PubSub<SomeMessageType>.Listen(SomeMessageEvent);
            }
            private static  void    SomeMessageEvent(SomeMessageType message)
            {
                Console.WriteLine("Attention! SomeMessageType receieved by SomeListener with\r\nid: {0}\r\ndescription: {1}\r\n", message.SomeId, message.SomeDescription);
            }
        }
        public  class   SomeOtherListener1
        {
            public  static  void    Listen()
            {
                PubSub<SomeOtherMessageType>.Listen(SomeMessageEvent);
            }
            private static  void    SomeMessageEvent(SomeOtherMessageType message)
            {
                Console.WriteLine("Heads up! SomeOtherMessageType receieved by SomeOtherListener1 with\r\namount: {0}\r\ndate: {1}\r\n", message.SomeAmount, message.SomeDate);
            }
        }
        public  class   SomeOtherListener2
        {
            public  static  void    Listen()
            {
                PubSub<SomeOtherMessageType>.Listen(SomeMessageEvent);
            }
            private static  void    SomeMessageEvent(SomeOtherMessageType message)
            {
                Console.WriteLine("Yo! SomeOtherMessageType receieved by SomeOtherListener2 withr\namount: {0}\r\ndate: {1}\r\n", message.SomeAmount, message.SomeDate);
            }
        }
    }
