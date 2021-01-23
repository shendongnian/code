        public class MyComponent : IComponent
    {
        public MyComponent(IDependencyFactory dependencyFactory)
        {
            DependencyFactory = dependencyFactory;
        }
        public void DoSomething(int argument)
        {
            var selectedDependency = DependencyFactory.Create(argument);
            selectedDependency.DoSomething();
        }
        public IDependencyFactory DependencyFactory { get; set; }
    }
