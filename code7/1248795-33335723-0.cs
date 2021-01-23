    Mapper.CreateMap<Source, Destination>()
        .ForMember(CreateMemberLambda<Destination>("Name"), mo => mo.MapFrom(sm => sm.Name));
    var source = new Source() { Name = "foo" };
    var destination = Mapper.Map<Destination>(source);
----------
    public Expression<Func<T, object>> CreateMemberLambda<T>(string parameterName)
    {
        var type = typeof(T);
        var bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        var parameter = type.GetProperty(parameterName, bindFlags);
        var classExpression = Expression.Parameter(type, type.Name);
        var memberAccessExpression = Expression.MakeMemberAccess(classExpression, parameter);
        var lambda = Expression.Lambda<Func<T, object>>(memberAccessExpression, classExpression);
        return lambda;
    }
