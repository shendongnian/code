    static class Program
    {
        static readonly BindingFlags flags = BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        static void Main() {
            var a = new A { PropA = new B() { PropB = "Value" } };
            var prop = GetPropertyRecursive("PropA.PropB", a);
        }
        static object GetPropertyRecursive(string property, object obj) {
            var splitted = property.Split('.');
            var value = obj.GetType().GetProperty(splitted[0], flags).GetValue(obj);
            if (value == null) {
                return null;
            }
            if (splitted.Length == 1) {
                return value;
            }
            return GetPropertyRecursive(string.Join(".", splitted.Skip(1)), value);
        }
    }
