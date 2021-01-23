    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Perso perso = new Perso();
            Func<bool> getWorlFarmeCollisionAsyncDelegate = perso.WorlFarmeCollision;
            getWorlFarmeCollisionAsyncDelegate.BeginInvoke(
                  (resultASync) =>
                  {
                      var methodDelegate = (Func<bool>)resultASync.AsyncState;
                      perso.Dispatcher.BeginInvoke(
                      new Action(() => perso.BoolProperty = methodDelegate.EndInvoke(resultASync)));
                  },
                  getWorlFarmeCollisionAsyncDelegate);
        }
    }
    public class Perso
    {
        public Dispatcher Dispatcher => Application.Current.Dispatcher;
        public bool BoolProperty { get; set; }
        public bool WorlFarmeCollision()
        {
            return true;
        }
    }
    
