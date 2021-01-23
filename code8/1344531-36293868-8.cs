    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Markup;
    namespace EdTest
    {
        [Flags]
        public enum TestEnum
        {
            Foo = 1 << 0,
            Bar = 1 << 1,
            Baz = 1 << 2,
            Ping = 1 << 3,
            Pong = 1 << 4,
            Hoop = 1 << 5,
            Floop = 1 << 6
        };
        public class EnumEnumerator : MarkupExtension
        {
            public EnumEnumerator(Type type)
            {
                _type = type;
            }
            private Type _type;
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return Enum.GetValues(_type);
            }
        }
    }
