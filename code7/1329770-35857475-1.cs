    public class Foo : IHasSomething {
        public void DoSomethingLikeSetValue(string s) {
            Console.WriteLine(s);
        }
    }
    
    var f = new Foo();
    QueueCheckNAdd<Foo>(f, "hello");
