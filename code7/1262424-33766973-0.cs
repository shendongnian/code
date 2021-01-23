    static void Main(string[] args)
    {
        WindsorContainer container = new WindsorContainer();
        var dependencies = new Dependency[2];
        dependencies[0] = Dependency.OnValue("x", "xV");
        dependencies[1] = Dependency.OnValue("y", "yV");
        container.Register(Component.For<IBla>().ImplementedBy<Bla>().DependsOn(dependencies));
        var bla = container.Resolve<IBla>();
    }
    public interface IBla 
    {
    }
    public class Bla : IBla
    {
        readonly string _x;
        readonly string _y;
        public Bla(string x, string y)
        {
            _x = x;
            _y = y;
        }
    }
