            Mapper.CreateMap<Result, Incident>()
                .ForMember(
                    dest => dest.Status,
                    opt => opt.ResolveUsing(src =>
                    {
                        var value = (ResolveCodeEnum)Enum.Parse(
                                        typeof(ResolveCodeEnum), src.state);
                
                        return EnumHelper.GetEnumDescription(value);
                    }));
