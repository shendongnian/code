    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Threading;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            DispatcherTimer timer = new DispatcherTimer();
    
            long currentlyRunningTasksCount;
    
            public MainWindow()
            {
                InitializeComponent();
    
                Loaded += MainWindow_Loaded;
    
                timer.Interval = TimeSpan.FromSeconds(1);
    
                timer.Tick += async (s, e) =>
                {
                    // Prevent re-entrance.
                    // Skip the current tick if a previous one is already in processing.
                    if (Interlocked.CompareExchange(ref currentlyRunningTasksCount, 1, 0) != 0)
                    {
                        return;
                    }
                    try
                    {
                        await ProcessTasks();
                    }
                    finally
                    {
                        Interlocked.Decrement(ref currentlyRunningTasksCount);
                    }
                };
            }
            
            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                // This one would crash, ItemsSource requires to be invoked from the UI thread.
                // ThreadPool.QueueUserWorkItem(o => { listView.Items.Add("started"); });
    
                listView.Items.Add("started");
    
                timer.Start();
            }
    
            async Task ProcessTasks()
            {
                var computed = await Task.Run(() => CpuBoundComputation());
    
                listView.Items.Add(string.Format("tick processed on {0} threads", computed.ToString()));
            }
    
            /// <summary>
            /// Computes Cpu-bound tasks. From here and downstream, don't try to interact with the UI.
            /// </summary>
            /// <returns>Returns the degree of parallelism achieved.</returns>
            int CpuBoundComputation()
            {
                long concurrentWorkers = 0;
    
                return
                    Enumerable.Range(0, 1000)
                    .AsParallel()
                    .WithDegreeOfParallelism(Math.Max(1, Environment.ProcessorCount - 1))
                    .Select(i =>
                    {
                        var cur = Interlocked.Increment(ref concurrentWorkers);
    
                        SimulateExpensiveOne();
    
                        Interlocked.Decrement(ref concurrentWorkers);
                        return (int)cur;
                    })
                    .Max();
            }
    
            /// <summary>
            /// Simulate expensive computation.
            /// </summary>
            void SimulateExpensiveOne()
            {
                // Prevent from optimizing out the unneeded result with GC.KeepAlive().
                GC.KeepAlive(Enumerable.Range(0, 1000000).Select(i => (long)i).Sum());
            }
        }
    }
