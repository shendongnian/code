    public class EntiEdit : Page
    {
        private string _entityId;
        protected override void OnNavigatedTo(NavigationEventArgs e) 
        {
            _entityId = e.Parameter as string;
        }
    }
