     public class MyDynamic : DynamicObject
    {
        private Dictionary<string,object> obj = new Dictionary<string, object>();
        public Func<string,dynamic,object> PropertyResolver { get; set; }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (obj.ContainsKey(binder.Name))
            {
                result =  obj[binder.Name];
                return true;
            }
            if (PropertyResolver != null)
            {
                var actResult = PropertyResolver(binder.Name, this);
                result = actResult;
                return true;
            }
            return base.TryGetMember(binder, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            obj[binder.Name] = value;
            return true;
        }
    }
     static void Main(string[] args)
        {
            dynamic person = new MyDynamic();
            person.Name = "Matt";
            person.Surname = "Smith";
            person.PropertyResolver = (Func<string, dynamic, object>)
                ((string name, dynamic me) => { return name == "FullName" ? me.Name + me.Surname : "";  });
    Console.WriteLine(person.FullName);
    }
