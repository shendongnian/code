    public static class DynamicObjectWrapperExtension {
        /// <summary>
        /// Return provided object as a <seealso cref="System.Dynamic.DynamicObject"/>
        /// </summary>  
        public static dynamic AsDynamicObject(this object value) {
            return new DynamicObjectWrapper(value);
        }
    }
    public class DynamicObjectWrapper : DynamicObject, IEquatable<DynamicObjectWrapper> {
        private readonly object value;
        private readonly Type valueType;
        public DynamicObjectWrapper(object value) {
            this.value = value;
            this.valueType = value.GetType();
        }
        public override IEnumerable<string> GetDynamicMemberNames() {
            return valueType.GetProperties().Select(p => p.Name);
        }
        public override bool TryConvert(ConvertBinder binder, out object result) {
            result = null;
            try {
                result = changeTypeCore(value, binder.Type);
            } catch {
                return false;
            }
            return true;
        }
        private object changeTypeCore(object value, Type convertionType) {
            if (ReferenceEquals(value, null))
                return getDefaultValueForType(convertionType);
            var providedType = valueType;
            if (convertionType.IsAssignableFrom(providedType)) {
                return value;
            }
            try {
                var converter = TypeDescriptor.GetConverter(convertionType);
                if (converter.CanConvertFrom(providedType)) {
                    return converter.ConvertFrom(value);
                }
                converter = TypeDescriptor.GetConverter(providedType);
                if (converter.CanConvertTo(providedType)) {
                    return converter.ConvertTo(value, convertionType);
                }
            } catch {
                return value;
            }
            try {
                return Convert.ChangeType(value, convertionType, System.Globalization.CultureInfo.CurrentCulture);
            } catch {
                return value;
            }
        }
        private object getDefaultValueForType(Type targetType) {
            return targetType.IsClass || targetType.IsInterface ? null : Activator.CreateInstance(targetType);
        }
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
            result = null;
            //1d collection
            if (potentialIndex(indexes)) {
                int index = (int)indexes[0];
                var list = value as IList;
                if (validIndex(index, list)) {
                    result = checkValue(list[index]);
                    return true;
                }
            }
            return false;
        }
        private bool validIndex(int index, IList list) {
            return index >= 0 && index < list.Count;
        }
        private bool potentialIndex(object[] indexes) {
            return indexes[0] != null && typeof(int) == indexes[0].GetType() && value is IList;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            return TryGetValue(binder.Name, out result);
        }
        public bool TryGetValue(string propertyName, out object result) {
            result = null;
            var property = valueType.GetProperty(propertyName);
            if (property != null) {
                var propertyValue = property.GetValue(value, null);
                result = checkValue(propertyValue);
                return true;
            }
            return false;
        }
        private object checkValue(object value) {
            var valueType = value.GetType();
            return isAnonymousType(valueType)
                ? new DynamicObjectWrapper(value)
                : value;
        }
        private bool isAnonymousType(Type type) {
            //HACK: temporary hack till a proper function can be implemented
            return type.Namespace == null &&
                type.IsGenericType &&
                type.IsClass &&
                type.IsSealed &&
                type.IsPublic == false;
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result) {
            try {
                result = valueType.InvokeMember(
                    binder.Name,
                    BindingFlags.InvokeMethod |
                    BindingFlags.Public |
                    BindingFlags.Instance,
                    null, value, args);
                return true;
            } catch {
                result = null;
                return false;
            }
        }
        public override bool Equals(object obj) {
            // If parameter is null return false.
            if (ReferenceEquals(obj, null)) return false;
            // Return true if the fields match:
            return this.value == obj || (obj is DynamicObjectWrapper && Equals(obj as DynamicObjectWrapper));
        }
        public bool Equals(DynamicObjectWrapper other) {
            // If parameter is null return false.
            if (ReferenceEquals(other, null)) return false;
            // Return true if the fields match:
            return this.value == other.value;
        }
        public override int GetHashCode() {
            return ToString().GetHashCode();
        }
        public override string ToString() {
            var name = GetType().Name;
            return string.Format("{0}[{1}]", name, value);
        }
    }
