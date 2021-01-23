    class Base
    {
        [Mark]
        public const string StringOnBase = "!?";
        private static readonly Dictionary<Type, string[]> fieldsPerInstance = new Dictionary<Type, string[]>();
 
        public bool ContainsMarked(string s)
        {
            var t = this.GetType();
            if (!fieldsPerInstance.ContainsKey(t))
            {
                fieldsPerInstance[t] = t
                    .GetFields(BindingFlags.Public)
                    .Where(f => f.GetCustomAttribute<MarkAttribute>() != null)
                    .Where(f => f.FieldType == typeof(string))
                    .Select(f => f.GetValue(this) as string)
                    .ToArray();
            }
            return fieldsPerInstance[t].Contains(s);
        }
    }
    class Derived : Base
    {
        [Mark]
        public const string StringA = "A";
        public const string OtherString = "!?";
    }
    class DerivedAgain : Derived
    {
        [Mark]
        public const string StringB = "B";
    }
    [AttributeUsage(AttributeTargets.Field)]
    class MarkAttribute : Attribute
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            var derived = new Derived();
            derived.ContainsMarked(DerivedAgain.StringB); // false
            derived.ContainsMarked(Base.StringOnBase); // true;
        }
    }
