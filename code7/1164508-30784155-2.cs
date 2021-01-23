    public class AObject : DynamicObject
    {
        public string PropertyA { get; set; }
        public int PropertyB { get; set; }
        #region Dynamic Part
        private readonly Dictionary<string, object> _members = new Dictionary<string, object>();
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            this._members[binder.Name] = value;
            return true;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return this._members.TryGetValue(binder.Name, out result) || base.TryGetMember(binder, out result);
        }
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return this._members.Keys;
        }
        #endregion
    }
