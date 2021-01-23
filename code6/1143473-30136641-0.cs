    public class FullData
    {
        static FullData()
        {
    
            Mapper.CreateMap<IEnumerable<RawData>, FullData>()
                .ForMember(d => d.Acres, m => m.ResolveUsing(new RawLeadDataNameResolver("Acres")));
        }
     }
