    public class Composer
    {
        public readonly ISet<Type> services;
        public Composer(ISet<Type> services)
        {
            this.services = services;
        }
        public Composer(params Type[] services) :
            this(new HashSet<Type>(services))
        {
        }
        public IEnumerable<Type> GetAvailableClients(params Type[] candidates)
        {
            return candidates.Where(CanCreate);
        }
        private bool CanCreate(Type t)
        {
            return t.GetConstructors().Any(CanCreate);
        }
        private bool CanCreate(ConstructorInfo ctor)
        {
            return ctor.GetParameters().All(p => 
                this.services.Contains(p.ParameterType));
        }
    }
