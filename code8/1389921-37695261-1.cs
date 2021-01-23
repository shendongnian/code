        public interface IDependency
        {
            int Argument { get; set; }
        }
        public abstract class DependencyBase : IDependency
        {
            public DependencyBase(int argument) { Argument = argument; }
            public int Argument { get; set; }
        }
    
        public class DependencyA : DependencyBase { public DependencyA() : base(1) {} }
        public class DependencyB : DependencyBase { public DependencyB() : base(2) {} }
        public interface IDependencyFactory
        {
            IDependency Create(int argument);
        }
    
        public interface IComponent { }
        public class MyComponent : IComponent
        {
            public MyComponent(IDependencyFactory dependencyFactory)
            {
                DependencyFactory = dependencyFactory;
            }
    
            public IDependencyFactory DependencyFactory { get; set; }
        }
        public class Installer : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(
                    Component.For<IDependency>().ImplementedBy<DependencyA>(),
                    Component.For<IDependency>().ImplementedBy<DependencyB>(),
                    Component.For<IDependencyFactory>().AsFactory(),
                    Component.For<IComponent>().ImplementedBy<MyComponent>());
            }
        }
