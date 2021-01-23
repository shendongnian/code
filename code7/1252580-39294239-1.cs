    public sealed class DisplayAttributeLocalizationProvider : IDisplayMetadataProvider
    {
        private IStringLocalizer _localizer;
    
        public DisplayAttributeLocalizationProvider(IStringLocalizer localizer)
        {
            _localizer = localizer;
        }
        
        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            context.PropertyAttributes?
                .Where(attribute => attribute is DisplayAttribute)
                .Cast<DisplayAttribute>().ToList().ForEach(display =>
                {
                    display.Name = _localizer[display.Name].Value;
                });
        }
    }
