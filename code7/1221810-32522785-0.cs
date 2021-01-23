    public class Sample
    {
        public string SampleExtraString { get; set; }
    }
    public class Factory
    {
        public class ExtraPropertyObject<T> : DynamicObject
        {
            private readonly T instance = default(T);
            private readonly Type instanceType = null;
            public ExtraPropertyObject(T instance) {
                this.instance = instance;
                instanceType = instance.GetType();
            }
            public override bool TrySetMember(SetMemberBinder binder, object value) {
                PropertyInfo prop = null;
                if (binder.Name.Equals("SampleExtraString")) {
                    Console.WriteLine(value);
                }
                prop = instanceType.GetProperty(binder.Name);
                if (prop != null) {
                    try {
                        prop.SetValue(instance, value);
                        return true;
                    }
                    catch (Exception ex) {
                    }
                }
                return false;
            }
            public override bool TryGetMember(GetMemberBinder binder, out object result) {
                var prop = instanceType.GetProperty(binder.Name);
                if (prop != null) {
                    try {
                        result = prop.GetValue(instance);
                        return true;
                    }
                    catch (Exception ex) {
                    }
                }
                result = null;
                return false;
            }
        }
        public static dynamic CreateInstance<TInstance>() where TInstance : class, new() {
            return new ExtraPropertyObject<TInstance>(new TInstance());
        }
        public static dynamic CreateInstance<TInstance>(TInstance instance) {
            return new ExtraPropertyObject<TInstance>(instance);
        }
    }
    class Program
    {
        static void Main(string[] args) {
            var instance = Factory.CreateInstance<Sample>();
            instance.SampleExtraString = "value";
            Console.WriteLine("Get Operation: {0}", instance.SampleExtraString);
        }
    }
