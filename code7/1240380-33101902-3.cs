    public class MainViewModel : ViewModelBase
    {
     
     private INavigationService navigationService;
 
     public RelayCommand DetailsCommand { get; set; }
 
     public MainViewModel(INavigationService navigationService)
     {
         this.navigationService = navigationService;
          //Show Terms and condition agreement;
          navigationService.NavigateTo("tnc");
 
         DetailsCommand = new RelayCommand(() =>
        {
            navigationService.NavigateTo("Details", "My data");
        });
     }
    }
