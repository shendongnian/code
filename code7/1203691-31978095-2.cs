    public enum DietType {Carnivore, Herbivore, Omnivore};
    
    public class FactoryAttribute : Attribute
    {
    	public Object Something { get; protected set; }
    }
    
    [AttributeUsage(System.AttributeTargets.Class)]
    public class DietTypeAttribute : FactoryAttribute
    {
        public DietTypeAttribute(DietType dietType)
        {
            this.Something = dietType;
        }
    }
    
    public abstract class Diet { }
    
    [DietTypeAttribute(DietType.Carnivore)]
    public class Carnivore : Diet
    {
    }
    
    [DietTypeAttribute(DietType.Herbivore)]
    public class Herbivore : Diet
    {
    }
    
    abstract class AbstractFactory<T> where T : class
    {
        protected Dictionary<Enum, Type> types;
    
        protected AbstractFactory()
        {
        }
    	
    	protected void Register<TEnumType, TSubType>()
    		where TEnumType: FactoryAttribute
    	{
    		
    		types = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                     from type in assembly.GetTypes()
                     let attributes = type.GetCustomAttributes(typeof(TEnumType), true)
                     where (attributes.Any()) && (typeof(TSubType).IsAssignableFrom(type)) && (type.IsClass)
                     select
                     new
                     {
                         dietEnum = (Enum)((TEnumType)attributes.First()).Something,
                         dietType = type
                     }).ToDictionary(x => x.dietEnum, x => x.dietType);
    	}
    
        public T CreateInstance(Enum id, params object[] param)
        {	
            return (T)Activator.CreateInstance(types[id], param);
        }
    }
    
    class DietFactory : AbstractFactory<Diet>
    {
        public DietFactory()
        {
            Register<DietTypeAttribute, Diet>(); 
        }
    }
