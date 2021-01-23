    public class ServiceMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Read values, and set Command binding and content property of Button btSwitch.
            // 0 for selected item
            // 1 for viewmodelmain
            // 2 for button
            if(values.IsNotEmpty() && values.IsExpectedQuantity(3))
            {
                Service selectedService = (Service)values[0];
                ViewModelMain viewModel = (ViewModelMain)values[1];
                Button btSwitch = (Button)values[2];
                if(selectedService.Status == "Running")
                {
                    btSwitch.IsEnabled = true;
                    btSwitch.Content = "Stop Service";
                    btSwitch.Command = viewModel.StopService;
                    btSwitch.CommandParameter = selectedService;
                }
                else if(selectedService.Status == "Stopped")
                {
                    btSwitch.IsEnabled = true;
                    btSwitch.Content = "Start Service";
                    btSwitch.Command = viewModel.StartService;
                    btSwitch.CommandParameter = selectedService;
                }
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
