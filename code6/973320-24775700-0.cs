    using System;
    using System.Reactive.Linq;
    
    namespace RxEventCombine
    {
        class Program
        {
            public event EventHandler event1;
            public event EventHandler event2;
            public event EventHandler event3;
    
            public Program()
            {
                event1 += Event1Completed;
                event2 += Event2Completed;
                event3 += Event3Completed;
            }      
    
            public void Event1Completed(object sender, EventArgs args)
            {
                Console.WriteLine("Event 1 completed");
            }
    
            public void Event2Completed(object sender, EventArgs args)
            {
                Console.WriteLine("Event 2 completed");
            }
    
            public void Event3Completed(object sender, EventArgs args)
            {
                Console.WriteLine("Event 3 completed");
            }
    
            static void Main(string[] args)
            {
                var program = new Program();
                
                var event1Observable = Observable.FromEventPattern<EventHandler,EventArgs>(h => program.event1 += h, h => program.event1 -= h);
                var event2Observable = Observable.FromEventPattern<EventHandler, EventArgs>(h => program.event2 += h, h => program.event2 -= h);
                var event3Observable = Observable.FromEventPattern<EventHandler, EventArgs>(h => program.event3 += h, h => program.event3 -= h);
    
                using (var subscription = Observable.Zip(event1Observable, event2Observable, event3Observable)
                    .Subscribe(l => Console.WriteLine("All events completed")))
                {
    
                    Console.WriteLine("Invoke event 1");
                    program.event1.Invoke(null, null);
    
                    Console.WriteLine("Invoke event 2");
                    program.event2.Invoke(null, null);
    
                    Console.WriteLine("Invoke event 3");
                    program.event3.Invoke(null, null);
                }
    
                Console.ReadKey();
            }
        }
    }
