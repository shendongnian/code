    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Threading;
    
    namespace TestApp
    {
        public partial class MainWindow : Window
        {
            PerformanceCounter cpuCounter;
            DispatcherTimer dtClockTime;
    
            public MainWindow()
            {
                InitializeComponent();
                this.Loaded += MainWindow_Loaded;
            }
    
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                InitializeCpuPerformanceCounter();
                InitializeDispatcherTimer();
            }
    
            void InitializeDispatcherTimer()
            {
                dtClockTime = new DispatcherTimer();
                dtClockTime.Interval = new TimeSpan(0, 0, 1); //in Hour, Minutes, Second.
                dtClockTime.Tick += dtClockTime_Tick;
                dtClockTime.IsEnabled = true;
                dtClockTime.Start();
            }
    
            void InitializeCpuPerformanceCounter()
            {
                cpuCounter = new PerformanceCounter();
                cpuCounter.CategoryName = "Processor";
                cpuCounter.CounterName = "% Processor Time";
                cpuCounter.InstanceName = "_Total";
            }
    
            private void dtClockTime_Tick(object sender, EventArgs e)
            {
                getCPUInfo();
            }
    
            public void getCPUInfo()
            {
                CPUUsage.Content = cpuCounter.NextValue() + "%";
            }
        }
    }
