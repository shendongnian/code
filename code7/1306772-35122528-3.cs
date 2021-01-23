    public class EnumClassMapper<T> :  PetaPoco.StandardMapper 
        where T : Headspring.Enumeration<T>   
    {
       public override Func<object, object> GetFromDbConverter(System.Reflection.PropertyInfo targetProperty, Type sourceType)
       {
           return (x) => Enumeration<T, int>.FromValue((int) x);
       }
       public override Func<object, object> GetToDbConverter(System.Reflection.PropertyInfo sourceProperty)
       {
           return (x) => ((T)x).Value;
       }
    }
    var builder = DatabaseConfiguration.Build()
        .UsingConnectionStringName("sqlite")
        .UsingDefaultMapper<ConventionMapper>(m =>
        {
            m.FromDbConverter = (targetProperty, sourceType) =>
            {
                if (targetProperty == null)
                    return null;
                var t = targetProperty.PropertyType;
                        if (t.BaseType == null || ! t.BaseType.IsGenericType) 
                            return null;
                        if (t.BaseType.GetGenericTypeDefinition() != typeof(Headspring.Enumeration<>))
                            return null;
                        return ((IMapper)Activator.CreateInstance(typeof(EnumClassMapper<>).MakeGenericType(t))).GetFromDbConverter(targetProperty, sourceType);
            };
            m.ToDbConverter = sourceProperty =>
            {
                if (sourceProperty == null)
                    return null;
                var t = sourceProperty.PropertyType;
                        if (t.BaseType == null || !t.BaseType.IsGenericType)
                            return null;
                        if (t.BaseType.GetGenericTypeDefinition() != typeof(Headspring.Enumeration<>))
                            return null;
                        return ((IMapper)Activator.CreateInstance(typeof(EnumClassMapper<>).MakeGenericType(t))).GetToDbConverter(sourceProperty);
            };
        });
    var db = builder.Create();
