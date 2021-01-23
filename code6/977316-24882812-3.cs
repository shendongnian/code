    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    
    namespace MultiThreadingGUI
    {
        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public partial class App : Application
        {
            public App()
            {
                Startup += new StartupEventHandler(App_Startup);
            }
    
            void App_Startup(object sender, StartupEventArgs e)
            {
                TestViewModel vm = new TestViewModel();
                MainWindow window = new MainWindow();
                window.DataContext = vm;
                vm.Start();
    
                window.Show();
            }
        }
    
        public class TestViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            public ObservableCollection<String> ListFromElsewhere { get; private set; }
            public String TextFromElsewhere { get; private set; }
            // Provides a mechanism for the ViewModel to marshal operations from
            // worker threads on the View's thread.  The GUI context will be set
            // during the MainWindow's Loaded event handler, when both the GUI
            // thread context and an instance of this class are both available.
            public SynchronizationContext ViewContext { get; set; }
    
            public TestViewModel()
            {
                // Provide a default context based on the current thread that
                // can be changed by the View, should it required a different one.
                // It just happens that in this simple example the Current context
                // is the GUI context, but in a complete application that may
                // not necessarily be the case.
                ViewContext = SynchronizationContext.Current;
            }
            internal void Start()
            {
                ListFromElsewhere = new ObservableCollection<string>();
                Task testTask = new Task(new Action(()=>
                {
                    int count = 0;
                    while (true)
                    {
                        TextFromElsewhere = Convert.ToString(count++);
    
                        // This is Marshalled on the correct thread by the framework.
                        PropertyChangedEventHandler RaisePropertyChanged = PropertyChanged;
                        if (null != RaisePropertyChanged)
                        {
                            RaisePropertyChanged(this, 
                                new PropertyChangedEventArgs("TextFromElsewhere"));
                        }
    
                        // ObservableCollections (amongst other things) are thread-centric,
                        // so use the SynchronizationContext supplied by the View to
                        // perform the Add operation.
                        ViewContext.Post(
                            (param) => ListFromElsewhere.Add((String)param), TextFromElsewhere);
    
                        Thread.Sleep(1000);
                    }
                }));
                _testTask.Start();
            }
        }
    }
