    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Windows.Threading;
    namespace PerformanceTest
    {
        /// 
        /// Interaction logic for MainWindow.xaml
        /// 
        public partial class MainWindow : Window
        {
            public BlockingCollection<string> outputProducer = new BlockingCollection<string>();
            public BlockingCollection<string> impOutputProducer = new BlockingCollection<string>();
            public BlockingCollection<string> errorProducer = new BlockingCollection<string>();
            public BlockingCollection<string> impErrorProducer = new BlockingCollection<string>();
            public BlockingCollection<string> logsProducer = new BlockingCollection<string>();
            public ObservableCollection<object> Output { get; set; }
            public ObservableCollection<object> Errors { get; set; }
            public ObservableCollection<object> Logs { get; set; }
            Dispatcher dispatcher;
            public MainWindow()
            {
                Bridge.Controller.Window = this;
                try
                {
                    InitializeComponent();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.ToString());
                    Console.WriteLine(ex.StackTrace);
                }
                dispatcher = Dispatcher;
                Output = new ObservableCollection<object>();
                Errors = new ObservableCollection<object>();
                Logs = new ObservableCollection<object>();
                Task.Run(() => Print(outputProducer, Output));
                Task.Run(() => Print(errorProducer, Errors));
                Task.Run(() => Print(logsProducer, Logs));
            }
            public void Print(BlockingCollection<string> producer, ObservableCollection<object> target)
            {
                try
                {
                    foreach (var str in producer.GetConsumingEnumerable())
                    {
                        dispatcher.Invoke(() =>
                        {
                            target.Insert(0, str);
                        }, DispatcherPriority.Background);
                    }
                }
                catch (TaskCanceledException)
                {
                    //window closing before print finish
                }
            }
            private void StartButton_Click(object sender, RoutedEventArgs e)
            {
                if (!Bridge.Controller.Running)
                {
                    Bridge.Controller.Running = true;
                    Bridge.Controller.PrintLotsOfText();
                }
            }
            private void EndButton_Click(object sender, RoutedEventArgs e)
            {
                Bridge.Controller.Running = false;
            }
        }
    }
