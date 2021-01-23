    public class MyViewModel
    {
        private IPropertyService _PropertyService;
        public MyViewModel(IPropertyService propertyService)
        {
            _PropertyService = propertyService;
        }
        public void AddProperty() //this is called from an ICommand
        {
            Property p = _PropertyService.GetProperty(CurrentItem);
            CurrentItem.Properties.Add(p);
            ItemProperties.Add(p);
        }
    }
