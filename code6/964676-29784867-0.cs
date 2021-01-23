    ...
    public partial class App : Application
    {
        public App()
        {
           var _mainView = new MainView();
           var _navPage = new NavigationPage(_mainView);
           MainPage = _navPage;
        }
        
       //.. the methods below are currently empty on mine, 
       //still figuring out some of the front end ..
       protected override void OnStart(){ }
       protected override void OnSleep(){ }
       protected override void OnResume(){ }    
    
    ...
