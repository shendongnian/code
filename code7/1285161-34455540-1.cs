    public class UnityBasedClassAFactory : IClassAFactory
    {
        private readonly IUnityContainer m_Container;
        public UnityBasedClassAFactory(IUnityContainer container)
        {
            m_Container = container;
        }
        public ClassA Create(ClassC class_c)
        {
            return m_Container.Resolve<ClassA>(new DependencyOverride<ClassC>(class_c));
        }
    }
