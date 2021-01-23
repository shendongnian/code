    public class SampleDynamicObject : DynamicObject
    {
        Dictionary<string, object> values = new Dictionary<string, object>();
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (binder.Name == "Fullname")
            {
                result = values["Name"] + " " + values["Surname"];
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
