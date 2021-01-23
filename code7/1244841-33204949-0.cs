    public interface IFindResourceService {
        object FindResource(object resourceKey);
    }
    public class FindResourceService : IFindResourceService {
        FrameworkElement _element;
        public FindResourceService(FrameworkElement startElement){
           _element = startElement;
        }
        public object FindResource(object resourceKey){
           return _element.FindResource(resourceKey);
        }
    }
    //the converter
    public class ResourceKeyToResourceConverter : IValueConverter {
        public IFindResourceService FindResourceService {get;set;}
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture){
            if(FindResourceService == null) return null;
            return FindResourceService.FindResource(value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture){
           throw new NotImplementedException();
        }
    }
    //your view-model, suppose it inherits from some base view-model
    //or implements INotifyPropertyChanged directly ...
    public class ViewModel : BaseVM {
        public ViewModel(IFindResourceService _service){
            ResourceKeyToResource.FindResourceService = _service;            
        }
        public static ResourceKeyToResourceConverter ResourceKeyToResource = new ResourceKeyToResourceConverter();
        //... define other properties, members for your view-model normally
        //...
    }
