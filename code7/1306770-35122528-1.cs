    public class EnumClassMapper<T> :  PetaPoco.StandardMapper 
        where T : Headspring.Enumeration<T>   
    {
       public override Func<object, object> GetFromDbConverter(System.Reflection.PropertyInfo targetProperty, Type sourceType)
       {
           if (targetProperty.PropertyType == typeof(T))
           {
               return (x) => Enumeration<T, int>.FromValue((int) x);
           }
           return base.GetFromDbConverter(targetProperty, sourceType);
       }
       public override Func<object, object> GetToDbConverter(System.Reflection.PropertyInfo sourceProperty)
       {
           if (sourceProperty.PropertyType == typeof(T))
           {
               return (x) => ((T)x).Value;
           }
           return base.GetToDbConverter(sourceProperty);
       }
    }
    var mt = typeof(EnumClassMapper<>);
    typeof(PetType).GetTypes()
		.Where(t => t.BaseType != null && t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == typeof(Headspring.Enumeration<>)
		.ToList()
		.ForEach(t => Mapper.Register(t, Activator.CreateInstance(mt.MakeGenericType(t)));
