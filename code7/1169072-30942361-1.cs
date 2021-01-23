    using System;
    using Autofac;
    using Autofac.Features.Indexed;
    
    namespace SingletonRepro
    {
      class Program
      {
        static void Main()
        {
          var builder = new ContainerBuilder();
    
          // You can still keep the Initialize call if you want.
          builder.RegisterType<Environment>().As<IEnvironment>().SingleInstance().OnActivated(args => args.Instance.Initialize());
          
          // Everything's in DI now, not just some things.
          builder.RegisterType<Simulator>().As<ISimulator>().SingleInstance();
          builder.RegisterType<IndependentClass>();
    
          // Using keyed services to choose the repository rather than newing things up.
          builder.RegisterType<RealRepository>().Keyed<IRepository>(SampleServiceType.RealThing);
          builder.RegisterType<SimulatedRepository>().Keyed<IRepository>(SampleServiceType.SimulatedThing);
          builder.RegisterType<SampleComponent>().WithParameter("serviceType", SampleServiceType.SimulatedThing);
    
          var context = builder.Build();
          using (var scope = context.BeginLifetimeScope())
          {
            // Using Lazy<T> in the IndependentClass to defer the need for
            // IEnvironment right away - breaks the dependency circle.
            var inst = scope.Resolve<IndependentClass>();
            inst.DoWork();
            Console.WriteLine("Instance: {0}", inst);
          }
        }
      }
    
      public interface IEnvironment
      {
        bool IsInitialized { get; }
      }
    
      public class Environment : IEnvironment
      {
        public SampleComponent _component;
    
        public Environment(SampleComponent component)
        {
          this._component = component;
        }
    
        public void Initialize()
        {
          this._component.DoSomethingWithRepo();
          this.IsInitialized = true;
        }
    
        public bool IsInitialized { get; private set; }
      }
    
      public interface ISimulator
      {
      }
    
      public class Simulator : ISimulator
      {
        public Simulator(IEnvironment environment)
        {
          this.Environment = environment;
        }
        public IEnvironment Environment { get; private set; }
      }
    
      public enum SampleServiceType
      {
        None = 0,
        RealThing,
        SimulatedThing,
      }
    
      public class SampleComponent
      {
        private IIndex<SampleServiceType, IRepository> _repositories;
    
        private SampleServiceType _serviceType;
    
        // Use indexed/keyed services to pick the right one from a dictionary
        // rather than newing up the repository (or whatever) manually.
        public SampleComponent(IIndex<SampleServiceType, IRepository> repositories, SampleServiceType serviceType)
        {
          this._repositories = repositories;
          this._serviceType = serviceType;
        }
    
        public void DoSomethingWithRepo()
        {
          // You could always take the service type parameter in this function
          // rather than as a constructor param.
          var repo = this._repositories[this._serviceType];
          repo.DoWork();
        }
      }
    
      public interface IRepository
      {
        void DoWork();
      }
    
      public class SimulatedRepository : IRepository
      {
        private ISimulator _simulator;
    
        public SimulatedRepository(ISimulator simulator)
        {
          this._simulator = simulator;
        }
    
        public void DoWork()
        {
        }
      }
    
      public class RealRepository : IRepository
      {
        public void DoWork()
        {
        }
      }
    
      public class IndependentClass
      {
        private Lazy<IEnvironment> _env;
    
        // Delaying the need for the IEnvironment in the constructor
        // can help break the circular dependency chain, as well as not
        // immediately checking that it's initialized. (Can you just
        // TRUST that it's initialized and call it good?)
        public IndependentClass(Lazy<IEnvironment> env)
        {
          this._env = env;
        }
    
        public void DoWork()
        {
          if (!this._env.Value.IsInitialized)
            throw new InvalidOperationException();
        }
      }
    }
