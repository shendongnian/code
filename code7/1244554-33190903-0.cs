    public void CreateMapBasedOnDictionary<TSource, TDestination>(IDictionary<string, string> mapping_dictionary)
    {
        var mapping_expression = AutoMapper.Mapper.CreateMap<TSource, TDestination>();
        foreach (var kvp in mapping_dictionary)
        {
            string source_property_name = kvp.Key;
            string destination_property_name = kvp.Value;
            Type member_type = typeof (TSource).GetProperty(source_property_name).PropertyType;
            mapping_expression = mapping_expression.ForMember(destination_property_name, x =>
            {
                typeof (IMemberConfigurationExpression<TSource>)
                    .GetMethod("MapFrom", new []{typeof(string)})
                    .MakeGenericMethod(member_type)
                    .Invoke(x, new[] { source_property_name });
            });
        }
    }
