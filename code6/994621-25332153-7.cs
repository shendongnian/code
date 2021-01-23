    public interface IServiceLocator {
      void Add<TFrom, TTo>() where TTo : TFrom;
      void BuildUp<T>(T instance);
      void BuildUp(Type type, object instance);
      void AddSingleton<TFrom, TTo>() where TTo : TFrom;
      void AddSingleton<TFrom, TTo>(string name) where TTo : TFrom;
      void AddSingleton(Type from, Type to, string name);
      void AddInstance<T>(T instance);
      T Resolve<T>();
      T Resolve<T>(string name);
    }
    
    public class ServiceLocator : IServiceLocator {
      private IUnityContainer m_Container = new UnityContainer();
      public void Add<TFrom, TTo>() where TTo : TFrom {
        m_Container.RegisterType<TFrom, TTo>();
      }
      public void BuildUp<T>(T instance) {
        m_Container.BuildUp<T>(instance);
      }
      public void BuildUp(Type type, object instance) {
        m_Container.BuildUp(type, instance);
      }
      public void AddSingleton<TFrom, TTo>() where TTo : TFrom {
        m_Container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
      }
      public void AddSingleton<TFrom, TTo>(string name) where TTo : TFrom {
        m_Container.RegisterType<TFrom, TTo>(name, new   ContainerControlledLifetimeManager());
      }
      public void AddSingleton(Type from, Type to, string name) {
        m_Container.RegisterType(from, to, name, new ContainerControlledLifetimeManager());
      }
      public void AddInstance<T>(T instance) {
        m_Container.RegisterInstance<T>(instance);
      }
      public T Resolve<T>() {
        return m_Container.Resolve<T>();
      }
      public T Resolve<T>(string name) {
        return m_Container.Resolve<T>(name);
      }
      private static IServiceLocator s_Instance;
      public static IServiceLocator Instance {
        get { return s_Instance; }
      }
      static ServiceLocator() {
        var instance = new ServiceLocator();
        instance.AddInstance<IServiceLocator>(instance);
        s_Instance = instance;
      }
    }
