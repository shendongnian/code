    using System;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public sealed class OrderAttribute : Attribute {
        private readonly int order_;
        public OrderAttribute(
          [CallerLineNumber] int order = 0) {
            order_ = order; }
        public int Order { get { return order_; } }
    }
    public class Test {
        public enum CurrencyId {
            [Order] USD = 840,
            [Order] UAH = 980,
            [Order] RUR = 643,
            [Order] EUR = 978,
            [Order] KZT = 398,
            [Order] UNSUPPORTED = 0
        }
        public static void Main() {
            foreach(FieldInfo fi in typeof(CurrencyId).GetFields()
              .Where(fi => fi.IsStatic)
              .OrderBy(fi => ((OrderAttribute)fi.GetCustomAttributes(
              	typeof(OrderAttribute), true)[0]).Order))
                Console.WriteLine(fi.GetValue(null).ToString());
        }
    }
