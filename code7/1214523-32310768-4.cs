    using System;
    using System.Linq.Expressions;
    using System.Runtime.Remoting.Messaging;
    using System.Runtime.Remoting.Proxies;
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using LazyHelper = DotNetSandbox.InterfaceNames<System.Lazy<object>>;
    
    namespace DotNetSandbox
    {
        // Use case / Example:
        [TestClass]
        public class InterfaceNamesTests
        {
            [TestMethod]
            public void InterfaceNamesTest()
            {
                // Option 1 - Not strongly typed
                string nameA = typeof(IConvertible).GetMethod("ToBoolean").Name;
                Console.WriteLine(nameA);    // OUTPUT: ToBoolean
                string nameB = typeof(Lazy<object>).GetProperty("IsValueCreated").Name;
                Console.WriteLine(nameB);    // OUTPUT: ToBoolean
    
                // *** Option 2 ***************
                Console.WriteLine();
                Console.WriteLine("Option 2 - Strongly typed way:");
                IConvertible @interface = InterfaceNames<IConvertible>.Create();
    
                Func<IFormatProvider, bool> func = @interface.ToBoolean;
                string name1 = func.Method.Name;
                Console.WriteLine(name1);   // OUTPUT: ToBoolean
    
                string propName = InterfaceNames<Lazy<object>>.GetPropertyName(i => i.IsValueCreated);
                Console.WriteLine(propName);   // OUTPUT: IsValueCreated
                //OR (For short version - declare alias using, see using region..)
                string propName2 = LazyHelper.GetPropertyName(i => i.IsValueCreated);
                Console.WriteLine(propName2);   // OUTPUT: IsValueCreated
    
    
                // Other options results with complex/unclear code.
            }
        }
    
        // Helper class
        public class InterfaceNames<T> : RealProxy
        {
            private InterfaceNames() : base(typeof(T)) { }
    
            public static T Create()
            {
                return (T)new InterfaceNames<T>().GetTransparentProxy();
            }
    
            public override IMessage Invoke(IMessage msg)
            {
                return null;
            }
    
            public static string GetName(Delegate d)
            {
                return d.Method.Name;
            }
    
            public static string GetPropertyName<TProp>(Expression<Func<T, TProp>> prop)
            {
                // Credits to p-s-w-g
                var body = prop.Body as MemberExpression;
                return body == null ? null : body.Member.Name;
            }
        }
    }
