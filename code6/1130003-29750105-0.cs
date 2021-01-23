    static IMappingExpression<TFrom, TTo> MapSuperDateTime<TFrom, TTo>(
        this IMappingExpression<TFrom, TTo> expression, 
        Expression<Func<TTo, object>> dest)
    {
        var datePropertyName = ReflectionHelper.FindProperty(dest).Name;
        var timezomePropertyName = datePropertyName + "Zone";
        var fromType = typeof (TFrom);
        var datePropertyGetter = fromType.GetProperty(datePropertyName).ToMemberGetter();
        var timezonePropertGetter = fromType.GetProperty(timezomePropertyName).ToMemberGetter();
        return expression.ForMember(dest, opt => opt.MapFrom(src => new SuperDateTime
        {
            Date = (DateTimeOffset)datePropertyGetter.GetValue(src),
            Timezone = (string)timezonePropertGetter.GetValue(src)         
        }));
    }
