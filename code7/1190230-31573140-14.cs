    using System;
    using System.Collections.Generic;
    namespace TestPubSub
    {
        public  class   Program
        {
            private static  PubSub<SomeMessageType>         pubSub1     = new PubSub<SomeMessageType>();
            private static  PubSub<SomeOtherMessageType>    pubSub2     = new PubSub<SomeOtherMessageType>();
            private static  SomeListener                    listener1   = new SomeListener();
            private static  SomeOtherListener1              listener2   = new SomeOtherListener1();
            private static  SomeOtherListener2              listener3   = new SomeOtherListener2();
            public  static  void                Main(string[] args)
            {
                Program.startListeners();
                Program.sendTestMessages();
                Program.stopConsoleFromExitingImmediately();
            }
            private static  void    startListeners()
            {
                Program.listener1.Listen(Program.pubSub1);
                Program.listener2.Listen(Program.pubSub2);
                Program.listener3.Listen(Program.pubSub2);
            }
            private static  void    sendTestMessages()
            {
                var publisher1  = new SomePublisher(Program.pubSub1);
                var publisher2  = new SomeOtherPublisher(Program.pubSub2);
                publisher1.DoSomethingCool("Hello world");
                publisher2.DoSomethingElse(DateTime.Now);
            }
            private static  void    stopConsoleFromExitingImmediately()
            {
                Console.ReadKey();
            }
        }
        public  class   PubSub<TMessage>
        {
            private List
                    <
                        Action
                        <
                            TMessage
                        >
                    >                   listeners   = new List<Action<TMessage>>();
            public  void                Listen(Action<TMessage> listener)
            {
                if (listener != null)   this.listeners.Add(listener);
            }
            public  void                Unlisten(Action<TMessage> listener)
            {
                if (listeners.Contains(listener))   this.listeners.Remove(listener);
            }
            public  void                Broadcast(TMessage message)
            {
                foreach(var listener in this.listeners) listener(message);
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
            private PubSub<SomeMessageType> pubSub;
            public                          SomePublisher(PubSub<SomeMessageType> pubSub)   { this.pubSub = pubSub; }
            public  void                    DoSomethingCool(string description)
            {
                var randomizer  = new Random();
                this.pubSub.Broadcast(new SomeMessageType(){SomeId = randomizer.Next(), SomeDescription = description});
            }
        }
        public  class   SomeOtherPublisher
        {
            private PubSub<SomeOtherMessageType>    pubSub;
            public                                  SomeOtherPublisher(PubSub<SomeOtherMessageType> pubSub) { this.pubSub = pubSub; }
            public  void    DoSomethingElse(DateTime when)
            {
                var randomizer  = new Random();
                this.pubSub.Broadcast(new SomeOtherMessageType(){SomeAmount = randomizer.NextDouble(), SomeDate = when});
            }
        }
        public  class   SomeListener
        {
            public  void    Listen(PubSub<SomeMessageType> pubSub)
            {
                pubSub.Listen(this.SomeMessageEvent);
            }
            private void    SomeMessageEvent(SomeMessageType message)
            {
                Console.WriteLine("Attention! SomeMessageType receieved by SomeListener with\r\nid: {0}\r\ndescription: {1}\r\n", message.SomeId, message.SomeDescription);
            }
        }
        public  class   SomeOtherListener1
        {
            public  void    Listen(PubSub<SomeOtherMessageType> pubSub)
            {
                pubSub.Listen(this.SomeMessageEvent);
            }
            private void    SomeMessageEvent(SomeOtherMessageType message)
            {
                Console.WriteLine("Heads up! SomeOtherMessageType receieved by SomeOtherListener1 with\r\namount: {0}\r\ndate: {1}\r\n", message.SomeAmount, message.SomeDate);
            }
        }
        public  class   SomeOtherListener2
        {
            public  void    Listen(PubSub<SomeOtherMessageType> pubSub)
            {
                pubSub.Listen(this.SomeMessageEvent);
            }
            private void    SomeMessageEvent(SomeOtherMessageType message)
            {
                Console.WriteLine("Yo! SomeOtherMessageType receieved by SomeOtherListener2 withr\namount: {0}\r\ndate: {1}\r\n", message.SomeAmount, message.SomeDate);
            }
        }
    }
