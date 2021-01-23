    public class ToDictionaryConverter : ITypeConverter<Model, KeyValuePair<int, ViewModel>>
    {
        public KeyValuePair<int, ViewModel> Convert(Model source, KeyValuePair<int, ViewModel> destination, ResolutionContext context)
        {
            return new KeyValuePair<int, ViewModel>(source.Id, context.Mapper.Map<ViewModel>(source));
        }
    }
