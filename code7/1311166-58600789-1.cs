using Mapper = AutoMappers.Mapper; <-- using statement changed
namespace ...
{
  public class ...
  {
        public ...(...)
        {
          Mapper.Initialize(cfg => cfg.CreateMap<TSource1, TDestination1>()); <-- other code line kept originally
--
