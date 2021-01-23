    public class MappingProfile : AutoMapper.Profile
    {
      public MappingProfile()
      {
         this.CreateMap<Parent, Parent>()
             .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
      }
    }
