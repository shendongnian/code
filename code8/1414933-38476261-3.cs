    static class UnityExtensions
    {
        public static void RegisterMultipleType<TInterface, TConcrete>(this IUnityContainer container)
        {
            var typeToBind = typeof(TConcrete);
            container.RegisterType(typeof(TInterface), typeToBind, typeToBind.Name);
        }
    }
    container.RegisterMultipleType<IWriter, FileWriter>();
