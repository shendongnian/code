         public class MyClass : IMyClass
        {
            private readonly IUnityContainer _container;
            
            #ctor
            // initialie the container through the constructor
        
            public void DoWork<Interface, Class>() where Class: Interface
            {
                _container.RegisterType<Interface, Class>(
                 //TODO: You can setup the container lifecycle which can be transient
                 // or singleton or custom based on your project requirement  
                 )
            }
        }
