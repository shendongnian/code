    public class ValueBridge<T> : IValueBridge<T>
	{
		object IValueBridge.GetValue(object instance, string attributeName)
		{
			return this.GetValue((T)instance, attributeName);
		}
		
		public object GetValue(T instance, string attributeName)
		{
			Func<T, object> f = // ...
			return f(instance);
		}
