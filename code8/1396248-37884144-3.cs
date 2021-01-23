    public class MainPaigeViewModel: ViewModelBase
    {
       
        public MainPaigeViewModel()
        {
            Task.Run(async () =>
            {
                Random random = new Random();
                while (true)
                {
                    await Task.Delay(1000);
                    int newValue = random.Next(-40, 40);
                    try
                    {
                        await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                        () => {
                            MyValue = newValue.ToString();
                        });
                       
                    }
                    catch (Exception ex)
                    {
                        string s = ex.ToString();
                    }
                    Debug.WriteLine(MyValue);
                }
            });
        }
        //Properties
        private string _MyValue;
        public string MyValue
        {
            get { return _MyValue; }
            set
            {
                _MyValue = value;
                OnPropertyChanged();
            }
        }
       
    }
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
