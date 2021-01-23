    using System;
    public static class Test {
        public struct ValueType : IFormattable {
            public override string ToString() => "Object.ToString";
            public string ToString(string format, IFormatProvider formatProvider) => "IFormattable.ToString";
        }
        public static void Main() {
            ValueType vt = new ValueType();
            Console.WriteLine($"{vt}");
            Console.WriteLine($"{vt.ToString()}");
        }
    }
