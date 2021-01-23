C#
void MapFrom<TResult>(Func<TSource, TDestination, TResult> mappingFunction);
Just adding another lambda/function parameter will dispatch to this new overload:
C#
        CreateMap<TSource, TDest>()
                .ForMember(dest => dest.SomeDestProp, opt => opt.MapFrom((src, dest) =>
                {
                    TSomeDestProp destinationValue;
                    // mapping logic goes here
                    return destinationValue;
                }));
