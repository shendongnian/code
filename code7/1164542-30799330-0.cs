    namespace CountdownTimer
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
       public partial class MainWindow : Window
       {
           TimeSpan runningTime;
           DispatcherTimer dt;
           public MainWindow()
           {
               InitializeComponent();
               
               // Fill in number of seconds to be countdown from
               runningTime = TimeSpan.FromSeconds(21600);
               dt = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
               {
                    lblTime.Content = runningTime.ToString(@"hh\:mm\:ss");
                    if (runningTime == TimeSpan.Zero) dt.Stop();
                    runningTime = runningTime.Add(TimeSpan.FromSeconds(-1));
               }, Application.Current.Dispatcher);
               dt.Start();
           }
       }
    }
