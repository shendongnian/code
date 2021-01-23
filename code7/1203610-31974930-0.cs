        public class Example
        {
            public void Start()
            {
                 Func<object, Task> func = o => null;
                 object objFunc = func; // got it from a generic place as an object or something
                 Type type = objFunc.GetType().GetGenericArguments()[0]; // get T in runtime
                 var method = typeof(Example).GetMethod("DoSomething", BindingFlags.Public | BindingFlags.Instance).MakeGenericMethod(type);
                 var result = method.Invoke(this, new object[1] { func });
            }
    
            public int DoSomething<T>(Func<T, Task> input)
            {
                return 1;
            }
        }
