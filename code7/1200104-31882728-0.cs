    namespace Omu.ValueInjecter
    {
        public partial class MapperActivations
        {
            public static ConcurrentDictionary<Type, Type> InterfaceActivations = new ConcurrentDictionary<Type, Type>();
            public static void AddInterfaceActivation<Interface, Class>()
            {
                InterfaceActivations.AddOrUpdate(typeof(Interface), typeof(Class), (key, oldValue) => typeof(Class));
            }
        }
    }
