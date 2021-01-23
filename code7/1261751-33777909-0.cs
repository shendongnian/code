    public class SomeClass
    {
        //Exposed as ISubject as I can't see usage of `Value` and `TryGetValue` are not present.
        private readonly ISubject<string> something;
        public SomeClass()
        {
            var source = new BehaviorSubject<string>(null);
            //Maybe this is actually what you want?
            //var source = new ReplaySubject<string>(1);
            this.something = Subject.Synchronize(source);
        }
        public IObservable<string> Something => this.something.AsObservable();
        // could be called from any thread
        public void SomeMethod()
        {
            // do some work
            this.something.OnNext("some calculated value");
        }
    }
