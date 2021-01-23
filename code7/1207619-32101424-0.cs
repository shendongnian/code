    [AttributeUsage(AttributeTargets.Class)]
    public class IdPropertyAttribute : Attribute
    {
        public string IdProperty { get; private set; }
        public IdPropertyAttribute(string idProperty) { this.IdProperty = idProperty; }
    }
    public static class TExtensions
    {
        public static Variance DetailedCompare<T>(this T val1, T val2)
        {
            return  val1.DetailedCompare(val2, null);
        }
        public static Variance DetailedCompare<T>(this T val1, T val2, string fieldName)
        {
            return  typeof(IEnumerable).IsAssignableFrom(typeof(T))
                    ?   TExtensions.enumerableCompare(val1, val2, fieldName)
                    :   typeof(T).IsPrimitive
                        ?   TExtensions.valueCompare(val1, val2, fieldName)
                        :   TExtensions.objectCompare(val1, val2, fieldName);
        }
        private static Variance valueCompare<T>(T val1, T val2, string fieldName)
        {
            return  val1 != null && val2 != null && !val1.Equals(val2)
                    ?   new Variance.ValueVariance<T>() { Prop = fieldName??"<root>", valA = val1, valB = val2 }
                    :   null;
        }
        private static Variance objectCompare<T>(T val1, T val2, string fieldName)
        {
            var variance = new Variance.EnumerableVariance() {Prop = fieldName};
            List<FieldInfo> fi = val1.GetType().GetRuntimeFields().ToList<FieldInfo>();
            foreach (FieldInfo f in fi)
            {
                var subVariance = f.GetValue(val1).DetailedCompare(f.GetValue(val2), f.Name);
                if (subVariance != null)    variance.variances.Add(subVariance);
            }
            return variance;
        }
        private static Variance enumerableCompare<T>(T val1, T val2, string fieldName)
        {
            return  typeof(IEnumerable<>).IsAssignableFrom(typeof(T))
                    ?   TExtensions.homogeneousEnumerableCompare<T>(val1, val2, fieldName)
                    :   TExtensions.heterogeneousEnumerableCompare<T>(val1, val2, fieldName);
        }
        private static Variance heterogeneousEnumerableCompare<T>(T val1, T val2, string fieldName)
        {
            throw new NotImplementedException();
        }
        private static Variance homogeneousEnumerableCompare<T>(T val1, T val2, string fieldName)
        {
            var subType     = typeof(T).GetGenericArguments()[0];
            return  typeof(KeyValuePair<,>).IsAssignableFrom(subType)
                    ?   TExtensions.homogeneousKeyValueEnumerableCompare(subType, val1, val2, fieldName)
                    :   subType.IsPrimitive
                        ?   homogeneousValueEnumerableCompare(subType, val1, val2, fieldName)
                        :   homogeneousObjectEnumerableCompare(subType, val1, val2, fieldName);
        }
        private static Variance homogeneousObjectEnumerableCompare<T>(Type subType, T val1, T val2, string fieldName)
        {
            var subMethod   =   typeof(TExtensions)
                                .GetMethod("typedHomogeneousObjectEnumerableCompare", BindingFlags.Static, null, new []{typeof(T), typeof(T), typeof(String)}, null)
                                .MakeGenericMethod(new []{typeof(T), subType});
            return (Variance) subMethod.Invoke(null, new object[] {val1, val2, fieldName});
        }
        private static Variance typedHomogeneousObjectEnumerableCompare<T, TSubType>(T val1, T val2, string fieldName)
        {
            var idAttribute = typeof(TSubType).GetCustomAttribute<IdPropertyAttribute>(true);
            return  idAttribute == null
                    ?   TExtensions.keyLessTypedHomogeneousObjectEnumerableCompare<T, TSubType>(val1, val2, fieldName)
                    :   TExtensions.keyedTypedHomogeneousObjectEnumerableCompare<T, TSubType>(idAttribute, val1, val2, fieldName);
        }
        private static Variance keyLessTypedHomogeneousObjectEnumerableCompare<T, TSubType>(T val1, T val2, string fieldName)
        {
            var list1 = (IEnumerable<TSubType>) val1;
            var list2 = (IEnumerable<TSubType>) val2;
            return  list1.Count() != list2.Count()
                    ?   new Variance.KeylessObjectEnumerableVariance() { Prop = fieldName, listACount = list1.Count(), listBCount = list2.Count() }
                    :   null;
        }
        private static Variance keyedTypedHomogeneousObjectEnumerableCompare<T, TSubType>(IdPropertyAttribute idAttribute, T val1, T val2, string fieldName)
        {
            var idMember    = typeof(TSubType).GetMember(idAttribute.IdProperty).FirstOrDefault();
            if (idMember == null) throw new IdMemberNotFoundException(idAttribute.IdProperty, typeof(TSubType).FullName);
            var subMethod   =   typeof(TExtensions)
                                .GetMethod("subTypedKeyedTypedHomogeneousObjectEnumerableCompare", BindingFlags.Static, null, new []{typeof(T), typeof(T), typeof(String)}, null)
                                .MakeGenericMethod(new []{typeof(T), typeof(TSubType), (idMember is PropertyInfo ? ((PropertyInfo) idMember).PropertyType : ((FieldInfo) idMember).FieldType)});
            return (Variance) subMethod.Invoke(null, new object[] {val1, val2, fieldName, idMember});
        }
        private static Variance subTypedKeyedTypedHomogeneousObjectEnumerableCompare<T, TSubType, TSubTypeKey>(T val1, T val2, string fieldName, MemberInfo idMember)
        {
            return  subTypedKeyedTypedHomogeneousObjectEnumerableCompareWithKeyFunc<T, TSubType, TSubTypeKey>
                    (
                        val1,
                        val2,
                        fieldName,
                        idMember is PropertyInfo
                        ?   new Func<TSubType, TSubTypeKey>(item=>(TSubTypeKey) ((PropertyInfo) idMember).GetValue(item))
                        :   item=>(TSubTypeKey) ((FieldInfo) idMember).GetValue(item)
                    );
        }
        private static Variance subTypedKeyedTypedHomogeneousObjectEnumerableCompareWithKeyFunc<T, TSubType, TSubTypeKey>(T val1, T val2, string fieldName, Func<TSubType, TSubTypeKey> getKey)
        {
            var set1        = ((IEnumerable<TSubType>) val1).ToDictionary(a=>getKey(a));
            var set2        = ((IEnumerable<TSubType>) val2).ToDictionary(a=>getKey(a));
            return TExtensions.DictionaryCompare<TSubTypeKey, TSubType>(set1, set2, fieldName);
        }
        private static Variance homogeneousValueEnumerableCompare<T>(Type subType, T val1, T val2, string fieldName)
        {
            var subMethod   =   typeof(TExtensions)
                                .GetMethod("typedHomogeneousValueEnumerableCompare", BindingFlags.Static, null, new []{typeof(T), typeof(T), typeof(String)}, null)
                                .MakeGenericMethod(new []{typeof(T), subType});
            return (Variance) subMethod.Invoke(null, new object[] {val1, val2, fieldName});
        }
        private static Variance typedHomogeneousValueEnumerableCompare<T, TSubType>(T val1, T val2, string fieldName)
        {
            var variance    = new Variance.EnumerableVariance();
            var list1       = ((IEnumerable<TSubType>) val1).ToList();
            var list2       = ((IEnumerable<TSubType>) val1).ToList();
            foreach(var item in list1)  if (!list2.Contains(item))  variance.variances.Add(new Variance.ValueRemovedVariance<TSubType>() {Prop = fieldName, value = item});
            foreach(var item in list2)  if (!list1.Contains(item))  variance.variances.Add(new Variance.ValueAddedVariance<TSubType>() {Prop = fieldName, value = item});
            return variance;
        }
        private static Variance homogeneousKeyValueEnumerableCompare<T>(Type subType, T val1, T val2, string fieldName)
        {
            var keyType     = subType.GetGenericArguments()[0];
            var valueType   = subType.GetGenericArguments()[1];
            var subMethod   =   typeof(TExtensions)
                                .GetMethod("typedHomogeneousKeyValueEnumerableCompare", BindingFlags.Static, null, new []{typeof(T), typeof(T), typeof(String)}, null)
                                .MakeGenericMethod(new []{typeof(T), keyType, valueType});
            return (Variance) subMethod.Invoke(null, new object[] {val1, val2, fieldName});
        }
        private static Variance typedHomogeneousKeyValueEnumerableCompare<T, TSubTypeKey, TSubTypeValue>(T val1, T val2, string fieldName)
        {
            var set1        = ((IEnumerable<KeyValuePair<TSubTypeKey, TSubTypeValue>>) val1).ToDictionary(a=>a.Key, a=>a.Value);
            var set2        = ((IEnumerable<KeyValuePair<TSubTypeKey, TSubTypeValue>>) val2).ToDictionary(a=>a.Key, a=>a.Value);
            return TExtensions.DictionaryCompare<TSubTypeKey, TSubTypeValue>(set1, set2, fieldName);
        }
        private static Variance DictionaryCompare<TSubTypeKey, TSubTypeValue>(Dictionary<TSubTypeKey, TSubTypeValue> set1, Dictionary<TSubTypeKey, TSubTypeValue> set2, string fieldName)
        {
            var variance    = new Variance.EnumerableVariance();
            foreach(var key in set1.Keys)
            {
                var subVariance =   !set2.ContainsKey(key) 
                                    ?   new Variance.KeyedObjectRemovedVariance<TSubTypeKey>() {Prop = fieldName, key = key}
                                    :   set1[key].DetailedCompare(set2[key], fieldName + "[" + key.ToString() + "]");
                if (subVariance != null) variance.variances.Add(subVariance);
            }
            foreach(var key in set2.Keys)  if (!set1.ContainsKey(key))  variance.variances.Add(new Variance.KeyedObjectRemovedVariance<TSubTypeKey>() {Prop = fieldName, key = key});
            return variance;
        }
    }
    public class IdMemberNotFoundException : ApplicationException
    {
        public IdMemberNotFoundException(string memberName, string typeName) : base(memberName + " was not found in type " + typeName +  ".") {}
    }
    public abstract class Variance
    {
        public string Prop { get; set; }
        
        public string GetChangedFromText() { return this.GetChangedFromText(null); }
        protected abstract string GetChangedFromText(string parent);
        public class ValueVariance<T> : Variance
        {
            public object valA { get; set; }
            public object valB { get; set; }
        
            protected override string GetChangedFromText(string parent)
            {
                return "value of " + (parent??"<root>") + "." + this.Prop + " has changed from " + this.valA + " to " + this.valB;
            }
        }
        public class EnumerableVariance : Variance
        {
            public List<Variance> variances   = new List<Variance>();
        
            protected override string GetChangedFromText(string parent)
            {
                StringBuilder   returnString    = new StringBuilder();
                foreach(var variance in this.variances)
                {
                    returnString.Append(variance.GetChangedFromText(this.Prop));
                }
                return returnString.ToString();
            }
        }
        public class KeylessObjectEnumerableVariance : Variance
        {
            public int listACount;
            public int listBCount;
            protected override string GetChangedFromText(string parent)
            {
                return "count of keyless items " + (parent??"<root>") + "." + this.Prop + " has changed from " + this.listACount.ToString() + " to " + this.listBCount.ToString();
            }
        }
        public class ValueRemovedVariance<T> : Variance
        {
            public T value;
            protected override string GetChangedFromText(string parent)
            {
                return "value " + this.value.ToString() + " of " + (parent??"<root>") + "." + this.Prop + " was removed.";
            }
        }
        public class ValueAddedVariance<T> : Variance
        {
            public T value;
            protected override string GetChangedFromText(string parent)
            {
                return "value " + this.value.ToString() + " of " + (parent??"<root>") + "." + this.Prop + " was added.";
            }
        }
        public class KeyedObjectRemovedVariance<T> : Variance
        {
            public T key;
            protected override string GetChangedFromText(string parent)
            {
                return "key " + this.key.ToString() + " of " + (parent??"<root>") + "." + this.Prop + " was removed.";
            }
        }
        public class KeyedObjectAddedVariance<T> : Variance
        {
            public T key;
            protected override string GetChangedFromText(string parent)
            {
                return "key " + this.key.ToString() + " of " + (parent??"<root>") + "." + this.Prop + " was added.";
            }
        }
    }
