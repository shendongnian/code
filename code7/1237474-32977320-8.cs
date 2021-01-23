    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace VirtualDispatchTest
    {
        interface ISubscribe
        {
            void Handle(IMessage msg);
            void Handle(StartMsg msg);
            //void Handle(ProgressMsg msg); // don't handle this one
            void Handle(EndMsg msg);
        }
    
        class MsgHandler: ISubscribe
        {
            // fall back, for unknown message types
            public void Handle(IMessage msg) { Console.Out.WriteLine("I'm not sure what I'm doing right now"); }
            public void Handle(StartMsg sm) { Console.Out.WriteLine("Here we go!"); }
    
            // Let's make his message type unknown
            //public void Handle(ProgressMsg pm) { Console.Out.WriteLine("Having fun making progress..."); }
            public void Handle(EndMsg em) { Console.Out.WriteLine("Bummer, already over."); }
        }
    
        interface IMessage
        {
            void CallSubscriberHandle(ISubscribe subscriber);
        }
    
        class StartMsg: IMessage
        {
            public void CallSubscriberHandle(ISubscribe subscr) { subscr.Handle(this); }
        }
    
        class ProgressMsg: IMessage
        {
            public void CallSubscriberHandle(ISubscribe subscr) { subscr.Handle(this); }
        }
    
        class EndMsg: IMessage
        {
            public void CallSubscriberHandle(ISubscribe subscr) { subscr.Handle(this); }
        }
    
        class Program
        {
            static List<IMessage> msgList = new List<IMessage>();
            
            static MsgHandler msgHandler = new MsgHandler();
    
            static void Main(string[] args)
            {
                msgList.Add(new StartMsg());
                msgList.Add(new ProgressMsg());
                msgList.Add(new EndMsg());
                
                msgList.Add(new StartMsg());
                msgList.Add(new EndMsg());
    
                foreach(IMessage msg in msgList)
                {
                    // Use virtual function dispatch in the message instead of
                    // a switch/case at the message handler
                    msg.CallSubscriberHandle(msgHandler);
                }
            }
        }
    }
