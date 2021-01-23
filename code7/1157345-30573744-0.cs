    // this is your converter
    public class ATypeConverter : ITypeConverter<string, A>
    {
        public A Convert(ResolutionContext context)
        {
              // implement conversion logic
        }
    }
    // add this in a bootstrapper in your app
    Mapper.CreateMap<string, A>().ConvertUsing<ATypeConverter>();
