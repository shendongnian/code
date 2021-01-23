    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading;
    using System.Windows;
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                // Initialize all the dots.
                var dotSeq = from x in Enumerable.Range(0, 30)
                             from y in Enumerable.Range(0, 90)
                             select new Dot(x * 10, y * 10);
                Dot[] allDots = dotSeq.ToArray();
                this.Dots = new ReadOnlyCollection<Dot>(allDots);
                // Start a dedicated background thread that picks a random dot,
                // flips its state, and then waits a little while before repeating.
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += delegate { RandomlyToggleAllDots(allDots); };
                bw.RunWorkerAsync();
                this.InitializeComponent();
            }
            public ReadOnlyCollection<Dot> Dots { get; }
            private static void RandomlyToggleAllDots(Dot[] allDots)
            {
                Random random = new Random();
                while (true)
                {
                    Dot dot = allDots[random.Next(allDots.Length)];
                    dot.IsOn = !dot.IsOn;
                    Thread.Sleep(1);
                }
            }
        }
    }
