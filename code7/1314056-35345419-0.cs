    public class MainWindowViewModel 
    {
        public MainWindowViewModel(ISessionContext sessionContext)
        {
            sessionContext.PropertyChanged += OnSessionContextPropertyChanged;        
        }
        private void OnSessionContextPropertyChanged(object sender, PropertyChangedEventArgs e) 
        {
            if (e.PropertyName == "EditorFontSize")
            {
                this.EditorFontSize = sessionContext.EditorFontSize;
            }
        }       
    }
