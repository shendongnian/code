    public class Generator<T>
    {
    	private readonly Random rnd;
        private List<Type> types = new List<Type>();
    
    	public Generator(Random r)
    	{
    		rnd = r;
    
    		if (!typeof(T).IsInterface)
                throw new Exception("Generator needs to be instanciated with an interface generic parameter");
    
            types = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.GetInterfaces().Contains(typeof(T))).ToList();
    	}
    
    	public T GetRandomObject()
        {
            int index = rnd.Next(types.Count);
            return (T)Activator.CreateInstance(types[index]);
        }
    }
    
    public class MetaGenerator
    {
    	private readonly Random rnd = new Random();
    
    	public Generator<T> Create<T>()
    	{
    		return new Generator<T>(rnd);
    	}
    }
    var metaGenerator = new MetaGenerator();
    
    var generator = metaGenerator.Create<IEnemy>();
    generator = metaGenerator.Create<IWeapon>();
