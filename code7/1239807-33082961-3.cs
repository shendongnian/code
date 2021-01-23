    class HasIndexedProperty {
        protected string get_PropertyName(int index1){
            // replace with your own implementation
            return string.Format("PropertyName: {0}", index1);
        }
        protected void set_PropertyName(int index1, string v){
            // this is an example - put your implementation here
        }
        public class HasIndexedProperty_PropertyName{
            protected HasIndexedProperty _owner;
            protected int _index1;
            internal HasIndexedProperty_PropertyName(
                HasIndexedProperty owner, int index1){
                _owner = owner; _index1 = index1;
            }
            // This line makes the property Value the default
            [DispId(0)]
            public string Value{
                get {
                    return _owner.get_PropertyName(_index1);
                }
                set {
                    _owner.set_PropertyName(_index1, value);
                }
            }
        }
    }
