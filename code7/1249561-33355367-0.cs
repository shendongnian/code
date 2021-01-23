    using System;
    namespace MyApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var p = new Publisher();
                var s1 = new Subscriber("first");
                s1.Subscribe(p);
                p.RaiseFoo(null, null);
                var s2 = new Subscriber("second");
                s2.Subscribe(p);
                p.RaiseFoo(null, null);
                p.EnumerateSubscribers();
                s1.Unsubscribe(p);
                p.RaiseFoo(null, null);
                s2.Unsubscribe(p);
                Console.ReadKey();
            }
        }
        public class Subscriber
        {
            public string Name { get; set; }
            public Subscriber(string name)
            {
                this.Name = name;
            }
            public void Subscribe(Publisher p)
            {
                p.Foo += this.HandleFoo;
            }
            public void Unsubscribe(Publisher p)
            {
                p.Foo -= this.HandleFoo;
            }
            private void HandleFoo(object sender, EventArgs e)
            {
                Console.WriteLine(this.Name + " is called");
            }
            public override string ToString()
            {
                return this.Name;
            }
        }
        public class Publisher
        {
            private int count;
            private EventHandler _foo;
            public void RaiseFoo(object sender, EventArgs e)
            {
                if (_foo != null)
                {
                    _foo(sender, e);
                }
            }
            public void EnumerateSubscribers()
            {
                if (_foo != null)
                {
                    foreach (var item in _foo.GetInvocationList())
                    {
                        Console.WriteLine("Subscriber object:" + item.Target?.ToString());
                    }
                }
            }
            public event EventHandler Foo
            {
                add
                {
                    _foo += value;
                    Console.WriteLine("Count:" + ++count);
                }
                remove
                {
                    _foo -= value;
                    Console.WriteLine("Count:" + --count);
                }
            }
        }
    
    }
