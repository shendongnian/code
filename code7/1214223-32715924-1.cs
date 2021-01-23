    public class DaddyActor : ReceiveActor
    {
        public DaddyActor()
        {
            Receive<DoneEatingMessage>(m =>
            {
                Console.WriteLine("Kid finished eating. So what? ~ Dad");
            });
        }
    }
    public class MummyActor : ReceiveActor
    {
        public MummyActor()
        {
            Receive<DoneEatingMessage>(m =>
            {
                Console.WriteLine("Kid finished eating. Time to clean up! ~Mummy");
            });
        }
    }
    public class KidActor : ReceiveActor
    {
        private IService _service;
        private IActorRef _mummyActor;
        private IActorRef _daddyActor;
        public KidActor(IService service, IParentFactory parentFactory)
        {
            this._service = service;
            this._mummyActor = parentFactory.CreateMother(Context.System);
            this._daddyActor = parentFactory.CreateFather(Context.System);
            Receive<EatMessage>(m =>
            {
                var food = service.GetFood();
                Console.WriteLine("Kid eat this food {0}", food);
                _mummyActor.Tell(new DoneEatingMessage());
                _daddyActor.Tell(new DoneEatingMessage());
            });
        }
    }
    public class EatMessage { }
    public class DoneEatingMessage { }
    public interface IService
    {
        string GetFood();
    }
    public class FoodService : IService
    {
        public string GetFood()
        {
            return "banana";
        }
    }
    public interface IParentFactory
    {
        IActorRef CreateMother(ActorSystem actorSystem);
        IActorRef CreateFather(ActorSystem actorSystem);
    }
    public class ParentFactory : IParentFactory
    {
        public IActorRef CreateFather(ActorSystem actorSystem)
        {
            return actorSystem.ActorOf(actorSystem.DI().Props<DaddyActor>(), "daddyActor");
        }
        public IActorRef CreateMother(ActorSystem actorSystem)
        {
            return actorSystem.ActorOf(actorSystem.DI().Props<MummyActor>(), "mummyActor");
        }
    }
    class Program
    {
        static ActorSystem _actorSystem;
        static void Main(string[] args)
        {
            var builder = new Autofac.ContainerBuilder();
            builder.RegisterType<FoodService>().As<IService>();
            builder.RegisterType<ParentFactory>().As<IParentFactory>();
            builder.RegisterType<MummyActor>().InstancePerDependency();
            builder.RegisterType<DaddyActor>().InstancePerDependency();
            builder.RegisterType<KidActor>().InstancePerDependency();
            var container = builder.Build();
            _actorSystem = ActorSystem.Create("ActorDISystem");
            var propsResolver = new AutoFacDependencyResolver(container, _actorSystem);
            var kidActorProps = _actorSystem.DI().Props<KidActor>();
            var kidActor = _actorSystem.ActorOf(kidActorProps, "kidActor");
            kidActor.Tell(new EatMessage());
            Console.WriteLine("Holah");
            Console.ReadLine();
            _actorSystem.AwaitTermination();
        }
    }
