<!-- -->
    public class ViewModelToViewConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
           //use naming convention or custom settings here to get view type
            var viewModelType = value.GetType();
            var viewType = ... 
            var view = (FrameworkElement) = YourIocContainer.GetInstance(viewType);
            view.DataContext = value;
            return view;
        }
        ...
     }
