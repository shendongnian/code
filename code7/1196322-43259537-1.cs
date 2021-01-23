    public class CoreProfile : Profile
    {
    	public CoreProfile()
    	{
    		CreateMap<Source, Dest>()
    		    .ForMember(d => d.Foo,
    		        opt => opt.ResolveUsing(
                        (src, dst, arg3, context) => context.Options.Items["Foo"]));
    	}
    }
