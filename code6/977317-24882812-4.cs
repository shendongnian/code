    using System;
    using System.Threading;
    using System.Windows;
    
    namespace MultiThreadingGUI
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                // The ViewModel object that needs to marshal some actions is
                // attached as the DataContext by the time of the loaded event.
                TestViewModel vmTest = (this.DataContext as TestViewModel);
                if (null != vmTest)
                {
                    // Set the ViewModel's reference SynchronizationContext to
                    // the View's current context.
                    vmTest.ViewContext = (SynchronizationContext)Dispatcher.Invoke
                        (new Func<SynchronizationContext>(() => SynchronizationContext.Current));
                }
            }
        }
    }
