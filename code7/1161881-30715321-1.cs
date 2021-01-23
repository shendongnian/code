        public class EnumValueResolver : ValueResolver<Result, string>
        {
            protected override string ResolveCore(Result src)
            {
                var value = (ResolveCodeEnum)Enum.Parse(typeof(ResolveCodeEnum), src.state);
                
                return EnumHelper.GetEnumDescription(value);    
            }
        }
    Usage:
        Mapper.CreateMap<Result, Incident>()
            .ForMember(
                dest => dest.Status,
                opt => opt.ResolveUsing<EnumValueResolver>());
