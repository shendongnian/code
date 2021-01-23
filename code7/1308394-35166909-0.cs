    using System.Reflection;
    namespace StackOverFlow35166571
    {
        public class ReflectionCalculator
        {
            public int Calculate(string action, int a, int b)
            {
                var methodInfo = this.GetType().GetMethod(action, BindingFlags.Instance | BindingFlags.NonPublic);
                var result = (int)methodInfo.Invoke(this, new object[] { a, b });
                return result;
            }
            private int Multiply(int a, int b)
            {
                return a * b;
            }
        }
    }
