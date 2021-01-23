    public class TestConverter<TBaseType> : JsonConverter
    {
        [ThreadStatic]
        static Stack<Type> typeStack;
        static Stack<Type> TypeStack { get { return typeStack = (typeStack ?? new Stack<Type>()); } }
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken token;
            using (TypeStack.PushUsing(value.GetType()))
            {
                token = JToken.FromObject(value, serializer);
            }
            // in practice this would be obtained dynamically
            string[] omit = new string[] { "Name" };
            JObject jObject = token as JObject;
            foreach (JProperty property in jObject.Properties().Where(p => omit.Contains(p.Name, StringComparer.OrdinalIgnoreCase)).ToList())
            {
                property.Remove();
            }
            token.WriteTo(writer);
        }
        public override bool CanConvert(Type objectType)
        {
            if (typeof(TBaseType).IsAssignableFrom(objectType))
            {
                return TypeStack.PeekOrDefault() != objectType;
            }
            return false;
        }
        public override bool CanRead { get { return false; } }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public static class StackExtensions
    {
        public struct PushValue<T> : IDisposable
        {
            readonly Stack<T> stack;
            public PushValue(T value, Stack<T> stack)
            {
                this.stack = stack;
                stack.Push(value);
            }
            #region IDisposable Members
            // By using a disposable struct we avoid the overhead of allocating and freeing an instance of a finalizable class.
            public void Dispose()
            {
                if (stack != null)
                    stack.Pop();
            }
            #endregion
        }
        public static T PeekOrDefault<T>(this Stack<T> stack)
        {
            if (stack == null)
                throw new ArgumentNullException();
            if (stack.Count == 0)
                return default(T);
            return stack.Peek();
        }
        public static PushValue<T> PushUsing<T>(this Stack<T> stack, T value)
        {
            if (stack == null)
                throw new ArgumentNullException();
            return new PushValue<T>(value, stack);
        }
    }
