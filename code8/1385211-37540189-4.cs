    using System;
    using System.Collections.Concurrent;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Threading;
    
    namespace WpfApplication2
    {
        public partial class MainWindow : Window
        {
            DispatcherTimer fastTimer = new DispatcherTimer();
    
            BackgroundProcessing processing = new BackgroundProcessing();
    
            public MainWindow()
            {
                InitializeComponent();
    
                processing.Start();
    
                fastTimer.Interval = TimeSpan.FromMilliseconds(10);
                fastTimer.Tick += Timer_Tick;
    
                fastTimer.Start();
            }
    
            private void Timer_Tick(object sender, EventArgs e)
            {
                Notification notification;
                while ((notification = processing.TryDequeue()) != null)
                {
                    listView.Items.Add(new { notification.What, notification.HappenedAt, notification.AttributedToATickOf });
                }        
            }
    
            protected override void OnClosing(CancelEventArgs e)
            {
                base.OnClosing(e);
                processing.Stop();
            }
        }
    
        public class Notification
        {
            public string What { get; private set; }
    
            public DateTime AttributedToATickOf { get; private set; }
    
            public DateTime HappenedAt { get; private set; }
    
            public Notification(string what, DateTime happenedAt, DateTime attributedToATickOf)
            {
                What = what;
                HappenedAt = happenedAt;
                AttributedToATickOf = attributedToATickOf;
            }
        }
    
        public class BackgroundProcessing
        {
            /// <summary>
            /// Different kind of timer, <see cref="System.Threading.Timer"/>
            /// </summary>
            Timer preciseTimer;
    
            ConcurrentQueue<Notification> notifications = new ConcurrentQueue<Notification>();
    
            public Notification TryDequeue()
            {
                Notification token;
                notifications.TryDequeue(out token);
                return token;
            }
    
            public void Start()
            {
                preciseTimer = new Timer(o =>
                {
                    var attributedToATickOf = DateTime.Now;
    
                    var r = new Random();
    
                    Parallel.ForEach(Enumerable.Range(0, 2), i => {
                        
                        Thread.Sleep(r.Next(10, 5000));
    
                        var happenedAt = DateTime.Now;
    
                        notifications.Enqueue(
                            new Notification("Successfully loaded cpu 100%", happenedAt, attributedToATickOf));
                    });
    
                }, null, 0, 1000);
            }
    
            public void Stop()
            {
                preciseTimer.Change(0, 0);
            }
        }
    }
