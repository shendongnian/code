    public class CoreProfile : Profile
    {
    	public CoreProfile()
    	{
    		CreateMap<Source, Dest>()
    		ForMember(
    		d => d.Foo,
    		opt => opt.ResolveUsing((Source, Dest, arg3, arg4) => arg4.Options.Items["Foo"]))
    	}
    }
