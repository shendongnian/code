    public class SelectedCategoryConverterCreatorExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new SelectedCategoryConverter();
        } 
    }
