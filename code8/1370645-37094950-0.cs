    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel(Observable.Interval(TimeSpan.FromSeconds(1)));
        }
    }
    public class ViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<long> _propertyHelper;
        public ViewModel(IObservable<long> factory)
        {
            factory.ObserveOn(RxApp.MainThreadScheduler).ToProperty(this, model => model.Property, out _propertyHelper);
        }
        public long Property => _propertyHelper.Value;
    }
