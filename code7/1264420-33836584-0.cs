    public class CatchAll : Attribute { }
    public static class EnumExtensions
    {
        public static T ToEnum<T, U>(this U value) where T : struct, IConvertible where U : struct, IComparable, IConvertible, IFormattable, IComparable<U>, IEquatable<U>
        {
            var result = (T)Enum.ToObject(typeof(T), value);
            var values = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            
            if (!values.Contains(result))
            {
                foreach (var enumVal in from enumVal in values
                                        let info = typeof(T).GetField(enumVal.ToString())
                                        let attrs = info.GetCustomAttributes(typeof(CatchAll), false)
                                        where attrs.Length == 1
                                        select enumVal)
                {
                    result = enumVal;
                    break;
                }
            }
            
            return result;
        }
    }
