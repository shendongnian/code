     public sealed partial class MainPage : Page, INotifyPropertyChanged
        {
            bool likeState=true;
            public bool LikeState 
            {
                get { return likeState; }
                set
                {
                    if(value!=likeState)
                    {
                        value = likeState;
                        OnPropertyChanged("LikeState");
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged(string propertyName)
            {
               if(this.PropertyChanged!=null)
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
             
            }
            public MainPage()
            {
                this.InitializeComponent();
    
                this.NavigationCacheMode = NavigationCacheMode.Required;
                LikeState = true;
                toggle.DataContext = this;
                
            }
    }
    
