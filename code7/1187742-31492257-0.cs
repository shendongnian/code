    public class Bar
    {
        private Foo _foo;
        public void Main()
        {
            _foo = new Foo();
            //do some stuff with foo...
            FooUtils.RegisterFoo(_foo, ReferenceChanger);
        }
        public void ReferenceChanger (Foo anotherFoo)
        {
            _foo = anotherFoo;
        }
    }
    public class Foo
    {
        public event EventHandler Invalid;
        //some more Properties/Fields/Methods and stuff but only the event is important for my question
    }
    public static class FooUtils
    {
        private static Dictionary<Foo, Action<Foo>> actionsToCallDictionary;
        public static void RegisterFoo( Foo foo, Action<Foo> changeReferenceAction)
        {
            foo.Invalid -= OnInvalid;
            if (actionsToCallDictionary != null)
                actionsToCallDictionary.Remove(foo);
            foo.Invalid += OnInvalid;
            if (actionsToCallDictionary == null)
                actionsToCallDictionary = new Dictionary<Foo, Action<Foo>>();
            actionsToCallDictionary[foo] = changeReferenceAction;
            
        }
        private static void OnInvalid(object sender, EventArgs args)
        {
            var foo = sender as Foo;
            if (foo != null)
            {
                //do some stuff...
                //create a new Instance and set it to ?!?
                Action<Foo> referenceChanger;
                if (actionsToCallDictionary != null && actionsToCallDictionary.TryGetValue(foo, out referenceChanger))
                {
                    var changeWith = new Foo();
                    referenceChanger(changeWith);
                }
            }
        }
    }
