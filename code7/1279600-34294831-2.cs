    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    using System.Windows.Threading;
    namespace StackOverflow
    {
        public partial class UserControl1 : UserControl, INotifyPropertyChanged
        {
            public UserControl1()
            {
                InitializeComponent();
                DataContext = this;
                _timer = new DispatcherTimer
                    { Interval = TimeSpan.FromSeconds(5), IsEnabled = true };
                _timer.Tick += (sender, e) => Task.Run(async () => await DoWorkAsync());
            }
            readonly DispatcherTimer _timer;
            readonly Random _random = new Random();
            public event PropertyChangedEventHandler PropertyChanged;
            public int Number
            {
                get
                {
                    return _number;
                }
                private set
                {
                    if (_number != value)
                    {
                        _number = value;
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("Number"));
                        }
                    }
                }
            }
            int _number;
            async Task DoWorkAsync()
            {
                // Asynchronous code started on a thread pool thread
                Console.WriteLine(GetType().Name + " starting work");
                _timer.IsEnabled = false;
                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(_random.Next(4, 12)));
                    Number++;
                }
                finally
                {
                    _timer.IsEnabled = true;
                }
                Console.WriteLine(GetType().Name + " finished work");
            }
        }
    }
