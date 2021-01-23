    public class WebsiteViewModel
    {
        //The website model
        public WebsiteModel Website { get; set; }
        //The command I will use to navigate, no parameters needed.
        public ICommand NavigateCommand { get; set; }
        ...
        public void Navigate()
        {  
           ...
    }
