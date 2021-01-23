        public interface IEnumProcessor 
        {
             IList<string> GetAllValues();
             bool ProcessInput(string userValue);
             Enum GetCurrentValue();
        }
    then refine that with a generic interface:
        public interface IEnumProcessor<TEnum> : IEnumProcessor where TEnum : struct, IConvertible, IComparable, IFormattable
             new TEnum GetCurrentValue();
             void AddSelectedValue(TEnum value);
        }
    and finally create a generic class with the actual code:
        public class EnumProcessor<T> where TEnum : struct, IConvertible, IComparable, IFormattable
        {
        }
    You can create instances of this processor with `MakeGenericType`, call methods with `MakeGenericMethod`, then pass it to other code you write as an IEnumProcessor if that code does not need to know the specific type of enum.
