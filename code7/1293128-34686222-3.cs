    public class MyViewModel : ViewModelBase
    {
        public MyViewModel()
        {
            DispatcherTimer timer = new DispatcherTimer(
                TimeSpan.FromSeconds(1),
                DispatcherPriority.Render,
                (sender, args) => Console.WriteLine(@"tick"),
                Application.Current.Dispatcher);
            timer.Start();
            CloseCommand = new RelayCommand(() => timer.Stop());
        }
        public ICommand CloseCommand { get; set; }
    }
