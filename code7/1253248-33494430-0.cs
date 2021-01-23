    public class WebsitesViewModel
    {
        //A list of websites.
        public List<WebsiteModel> Websites { get; set; }
        //The command I will use to navigate, where the object parameter will be the WebsiteModel.
        public ICommand NavigateCommand { get; set; }
        ...
        public void Navigate(WebsiteModel model)
        {  
           ...
    }
