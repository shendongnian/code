    namespace ViewModel
{
    class Page2ViewModel : PageViewModelBase
    {
        
        
        public Page2ViewModel()
        {
            Heading = "Page 2";
            //new USBmiddleware().FindDevices();
            List<Devices> devices = USBmiddleware.MyWildDevices();
        }
        public override void ButtonContinueClick()
        {
            Page3ViewModel vm = new Page3ViewModel();
            Page3 p3 = new Page3();
            p3.DataContext = vm;
            Navigator.NavigationService.Navigate(p3);
        }
    }
