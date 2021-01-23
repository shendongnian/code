    class DynamicDictionary : DynamicObject {
        private Dictionary<string, object> Dict = new Dictionary<string, object>();
    
        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            result = Dict[binder.Name];
            
            return true;
        }
    }
