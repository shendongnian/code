    public partial class MainWindow : Window
        {
            public static List<SignalRounding> SignalR;
    
            public MainWindow()
            {
                InitializeComponent();
                SignalR = new List<SignalRounding>();
    
                var r = SignalR.Where(t => t.time >= DateTime.Now.AddMinutes(-10))
                    .GroupBy(g => g.symbol)
                    .Select(s => new {Symbol = s.Key, Quantity = s.Count(), LastUpdated = s.Max(x => x.time)})
                    .OrderByDescending(x => x.LastUpdated)
                    .ThenByDescending(x => x.Quantity);
    
                addStuff();
    
                lv.ItemsSource = r;
            }
    
            private void addStuff()
            {
                for (int i = 0; i < 15; i++)
                {
                    SignalR.Insert(0, new SignalRounding()
                    {
                        time = DateTime.Now,
                        symbol = i % 10 == 0 ? "second" : i % 5 == 0 ? "third" : "first",
                        price = 0.25 * i,
                        round = i
                    });
                    Thread.Sleep(500);
                }
            }
        }
    
    
        public class SignalRounding
        {
            public DateTime time { get; set; }
            public string symbol { get; set; }
            public double price { get; set; }
            public double round { get; set; }
        }
