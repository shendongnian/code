    dynamic person = new GetterExpando();
    person.Name = "Matt";
    person.Surname = "Smith";
    person.FullName = new GetterExpando.Getter(x => x.Name + " " + x.Surname);
    Console.WriteLine(person.FullName);  // Matt Smith
    // ...
    public sealed class GetterExpando : DynamicObject
    {
        private readonly Dictionary<string, object> _data = new Dictionary<string, object>();
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _data[binder.Name] = value;
            return true;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            object value;
            if (_data.TryGetValue(binder.Name, out value))
            {
                var getter = value as Getter;
                result = (getter == null) ? value : getter._func(this);
                return true;
            }
            return base.TryGetMember(binder, out result);
        }
        public sealed class Getter
        {
            internal readonly Func<dynamic, object> _func;
            public Getter(Func<dynamic, object> func) { _func = func; }
        }
    }
