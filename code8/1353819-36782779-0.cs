    namespace ResString
    {
        public interface IResourceResolver
        {
            string Resolve(string key, string defaultValue);
        }
        public class ResourceString
        {
            public ResourceString(string value)
            {
                this.defaultValue = value;
                GetOwner();
            }
            public string Value
            {
                get
                {
                    if (!resolved)
                        Resolve();
                    return value;
                }
            }
            public override string ToString()
            {
                return Value;
            }
            public static implicit operator string(ResourceString rhs)
            {
                return rhs.Value;
            }
            public static implicit operator ResourceString(string rhs)
            {
                return new ResourceString(rhs);
            }
            protected virtual void Resolve()
            {
                if (Resolver != null)
                {
                    if (key == null)
                        key = GetKey();
                    value = Resolver.Resolve(key, defaultValue);
                }
                else
                {
                    value = defaultValue;
                }
                resolved = true;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            protected virtual void GetOwner()
            {
                StackTrace trace = new StackTrace();
                StackFrame frame = null;
                int i = 1;
                while (i < trace.FrameCount && (owner == null || typeof(ResourceString).IsAssignableFrom(owner)))
                {
                    frame = trace.GetFrame(i);
                    MethodBase meth = frame.GetMethod();
                    owner = meth.DeclaringType;
                    i++;
                }
            }
            protected virtual string GetKey()
            {
                string result = owner.FullName;
                FieldInfo field = owner.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static).Where(f =>
                    typeof(ResourceString).IsAssignableFrom(f.FieldType) && f.GetValue(null) == this
                ).FirstOrDefault();
                if (field != null)
                    result += "." + field.Name;
                return result;
            }
            public static IResourceResolver Resolver { get; set; }
            private string defaultValue;
            private string value;
            private bool resolved;
            private string key;
            private Type owner;
        }
    }
