    public class OrderDetailsViewModel : ViewModelBase, INavigationAware
    {
        public async void OnNavigatedFrom(object parameter) 
        {
            var orderId = (int)parameter;
            var order = await orderRepository.GetOrderByIdAsync(orderId);
            // display your order in the ViewModel here
        }
    }
