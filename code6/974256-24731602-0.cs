    namespace CSharpWPF
    {
        class SlowConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return new AsyncTask(() =>
                 {
                     Thread.Sleep(4000); //long running job eg. download image.
                     return "success";
                 });
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
            public class AsyncTask : INotifyPropertyChanged
            {
                public AsyncTask(Func<object> valueFunc)
                {
                    AsyncValue = "loading async value"; //temp value for demo
                    LoadValue(valueFunc);  
                }
                private async Task LoadValue(Func<object> valueFunc)
                {
                    AsyncValue =  await Task<object>.Run(()=> 
                        {
                            return valueFunc();
                        });
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("AsyncValue"));
                }
                public event PropertyChangedEventHandler PropertyChanged;
                public object AsyncValue { get; set; }
            }
        }
    }
