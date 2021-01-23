       public sealed partial class MainPage : Page, INotifyPropertyChanged
            {
                   ViewModel viewModel;
                    public ViewModel PageViewModel
                    {
                        get
                        {
                            return viewModel;
                           
                        }
                        set
                        {
                            if(viewModel!=value)
                            {
                                viewModel= value;
                                OnPropertyChanged("PageViewModel");
                            }
                        }
                    }
    
                    public event PropertyChangedEventHandler PropertyChanged;
    
                    protected void OnPropertyChanged(string propertyName)
                    {
                        // the new Null-conditional Operators are thread-safe:
                        this.PropertyChanged?.Invoke(this, new          PropertyChangedEventArgs(propertyName));
    
                    }
    
     public MainPage()
     {
                       this.SizeChanged += MainPage_SizeChanged;
                        PageViewModel=(ViewModel) DataContext;
     }
    
    private void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
    {
     PageViewModel.ScreenWidth =(int)     Window.Current.Bounds.Width;
                        Debug.WriteLine(Vm.ScreenWidth);
    }
    
    }
