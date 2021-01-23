public static IMappingExpression<TSource, TDestination> PreCondition<TSource, TDestination>(
   this IMappingExpression<TSource, TDestination> mapping
 , Func<TSource, bool> condition
)
   where TDestination : new()
{
   // This will configure the mapping to return null if the source object condition fails
   mapping.ConstructUsing(
      src => condition(src)
         ? new TDestination()
         : default(TDestination)
   );
   // This will configure the mapping to ignore all member mappings to the null destination object
   mapping.ForAllMembers(opt => opt.PreCondition(condition));
   return mapping;
}
For the case in question, it can be used like this:
Mapper.CreateMap<Foo, Bar>()
      .PreCondition(src => src.Code == 0);
Now, if the condition fails, the mapper will return null; otherwise, it will return the mapped object.
