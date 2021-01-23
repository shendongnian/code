    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var methodInfo in typeof(TestClass).GetMethods())
            {
                if (!methodInfo.IsSpecialName)
                    continue;
                CheckMethod(methodInfo);
            }
            // Method get_Name -> Property Get
            // Method set_Name -> Property Set
            // Method add_NameChanged -> Event Add/Remove
            // Method remove_NameChanged -> Event Add/Remove
        }
        static void CheckMethod(MethodInfo info)
        {
            var parameter = info.GetParameters().FirstOrDefault();
            if (parameter != null)
            {
                if (parameter.ParameterType.BaseType == typeof(MulticastDelegate))
                {
                    Trace.WriteLine($"Method {info.Name} -> Event Add/Remove");
                }
                else
                {
                    Trace.WriteLine($"Method {info.Name} -> Property Set");
                }
            }
            else if (info.ReturnType != typeof(void))
            {
                Trace.WriteLine($"Method {info.Name} -> Property Get");
            }
        }
    }
    public class TestClass
    {
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NameChanged?.Invoke(this, value);
            }
        }
        private string _name;
        public event EventHandler<string> NameChanged;
    }
