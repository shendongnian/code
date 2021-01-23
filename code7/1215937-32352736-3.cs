    public class IsCurrentlySelectedConverter : IValueConverter
    {
       public MainViewModel MainViewModel { get; set;}
       public object Convert(object value, ....)
       {
          return (value == MainViewModel.CurrentlySelectedCar);              
       }
    }
