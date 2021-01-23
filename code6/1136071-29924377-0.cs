    public class SampleDynamicObject : DynamicObject
    {
        Dictionary<string, Func<dynamic, object>> customFieldHandlers = new Dictionary<string, Func<dynamic, object>>();
        Dictionary<string, object> values = new Dictionary<string, object>();
        public void Get(string property, Func<dynamic, object> handler)
        {
            customFieldHandlers.Add(property, handler);
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (customFieldHandlers.ContainsKey(binder.Name))
            {
                result = customFieldHandlers[binder.Name](this);
                return true;
            }
            result = values[binder.Name];
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            values[binder.Name] = value;
            return true;
        }
    }
    dynamic sampleObject = new SampleDynamicObject();
            sampleObject.Get("FullName", (Func<dynamic, object>)((o) => 
            {
                dynamic obj = o;
                return o.Name + " " + o.Surname; 
            }));
