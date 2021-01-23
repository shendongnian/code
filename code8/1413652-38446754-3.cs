    public class DynamicObjectResultValue : DynamicObject, IEquatable<DynamicObjectResultValue> {
        private readonly object value;
        public DynamicObjectResultValue(object value) {
            this.value = value;
        }
        #region Operators
        public static bool operator ==(DynamicObjectResultValue a, DynamicObjectResultValue b) {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b)) {
                return true;
            }
            // If one is null, but not both, return false.
            if (ReferenceEquals((object)a, null) || ReferenceEquals((object)b, null)) {
                return false;
            }
            // Return true if the fields match:
            return a.value == b.value;
        }
        public static bool operator !=(DynamicObjectResultValue a, DynamicObjectResultValue b) {
            return !(a == b);
        }
        #endregion
        public override IEnumerable<string> GetDynamicMemberNames() {
            return value.GetType().GetProperties().Select(p => p.Name);
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            //initialize value
            result = null;
            //Search possible matches and get its value
            var property = value.GetType().GetProperty(binder.Name);
            if (property != null) {
                // If the property is found, 
                // set the value parameter and return true. 
                var propertyValue = property.GetValue(value, null);
                result = propertyValue;
                return true;
            }
            // Otherwise, return false. 
            return false;
        }
        public override bool TryConvert(System.Dynamic.ConvertBinder binder, out object result) {
            result = null;
            try {
                //convert value to requested type
                result = Convert.ChangeType(value, binder.Type);
                //conversion successful
                return true;
            } catch {
                //Convertion failed. reset.
                result = null;
            }
            return base.TryConvert(binder, out result);
        }
        public override bool Equals(object obj) {
            if (obj is DynamicObjectResultValue)
                return Equals(obj as DynamicObjectResultValue);
            // If parameter is null return false.
            if (ReferenceEquals(obj, null)) return false;
            // Return true if the fields match:
            return this.value == obj;
        }
        public bool Equals(DynamicObjectResultValue other) {
            // If parameter is null return false.
            if (ReferenceEquals(other, null)) return false;
            // Return true if the fields match:
            return this.value == other.value;
        }
        public override int GetHashCode() {
            return ToString().GetHashCode();
        }
        public override string ToString() {
            return string.Format("{0}", value);
        }
    }
