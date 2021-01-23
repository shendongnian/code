    interface IConverter
    {
        bool Convert(string str, out object val);
    }
    public abstract class Converter<T> : IConverter
    {
        public abstract bool Convert(string str, out T val);
		bool IConverter.Convert(string str, out object val)
		{
			T result = default(T);
			var success = this.Convert(str, out result);
			val = result;
			return success;
		}
    }
    
    public class StringToFooConverter : Converter<Foo>
    {
        public override bool Convert(string str, out Foo val)
        {
            //do the parsing here
        }
    }
