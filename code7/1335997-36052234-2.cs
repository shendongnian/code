    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    namespace SampleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var eventList = new List<IEvent> { new SomeClass() };
    
                using (MyObject obj = new MyObject(new MessageService()))
                {
                    foreach (IEvent myEvent in eventList)
                    {
                        myEvent.Execute();
                    }
                }
            }
        }
    
        public interface IEvent
        {
            void Execute();
        }
    
        public class SomeClass : IEvent
        {
            public void Execute()
            {
                var stackTrace = new StackTrace();
                var stackFrames = stackTrace.GetFrames();
                var callingMethod = stackFrames[1].GetMethod();
                var callingType = callingMethod.DeclaringType;
            }
        }
    
        public class MyObject : IDisposable
        {
            public MessageService Service { get; }
    
            public MyObject(MessageService service)
            {
                Service = service;
            }
    
            public void Dispose()
            {
                Service.Stop();
            }
        }
    
        public class MessageService
        {
            public void Start() { }
            public void Stop() { } 
        }
    }
