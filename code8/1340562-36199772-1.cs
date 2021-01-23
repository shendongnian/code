    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Timers;
    using System.Windows;
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                var dotSeq = from x in Enumerable.Range(0, 30)
                             from y in Enumerable.Range(0, 90)
                             select new Dot(x * 10, y * 10);
                Dot[] allDots = dotSeq.ToArray();
                this.Dots = new ReadOnlyCollection<Dot>(allDots);
                Timer updateTimer = new Timer();
                // update the dots every 0.2 seconds.
                updateTimer.Interval = 200;
                Random random = new Random();
                updateTimer.Elapsed += (_, __) =>
                    Array.ForEach(allDots, dot => dot.IsOn = random.Next() % 2 == 0);
                updateTimer.Start();
                this.InitializeComponent();
            }
            public ReadOnlyCollection<Dot> Dots { get; }
        }
    }
