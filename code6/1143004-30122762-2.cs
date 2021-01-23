    [AttributeUsage(AttributeTargets.Class)]
    public class NameAttribute : Attribute {
        public readonly string Name;
        public NameAttribute(string name) {
            this.Name = name;
        }
    }
    public static class Extensions {
        /// <summary>
        /// If existant, returns the name tag for given object, else null
        /// </summary>
        public static string GetNameTag(this object instance) {
            return instance.GetType().GetNameTag();
        }
        /// <summary>
        /// If existant, returns the name tag for given type, else null
        /// </summary>
        public static string GetNameTag(this Type type) {
            object[] names = type.GetCustomAttributes(typeof(NameAttribute), false);
            switch(names.Length) {
                case 0:
                    return null;
                case 1:
                    return ((NameAttribute)names[0]).Name;
                default:
                    throw new FormatException();
            }
        }
    }
    [Name("Headquater")]
    public class Headquater : Building {
        // ...
    }
    [Name("Solar Panel")]
    public class Solarpanel : Building {
        // ...
    }
