    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Markup;
    namespace EdTest
    {
        public enum TestEnum
        {
            Foo, Bar, Baz, Ping, Pong, Fling, Flong, Hoop, Floop, Cat, Kitten, Mortadella
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
