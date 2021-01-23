    public class YourCustomResolver : ValueResolver<FromModel, ToPartOfModel>
    {
    	protected override ToPartOfModel ResolveCore(FromModel)
    	{
    		// Your manual mapping or another call to AutoMapper
    	}
    }
    // Configuring mapper
    AutoMapper.Mapper.CreateMap<FromModel, ToModel>().
    	ForMember(o => o.ImageLogoMin, opt => opt.ResolveUsing<YourCustomResolver >().ConstructedBy(() => new YourCustomResolver ()));
