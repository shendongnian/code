    public MainWindow()
            {
                InitializeComponent();
                List<Competitor> list = new List<Competitor>();
                list.Add(new Competitor { Name = "Renee", Sname = "Lewallen", Laps = new List<TimeSpan> { TimeSpan.Parse("00:10"), TimeSpan.Parse("00:20"), TimeSpan.Parse("00:30") } });
                list.Add(new Competitor { Name = "Barney", Sname = "Fett", Laps = new List<TimeSpan> { TimeSpan.Parse("00:10"), TimeSpan.Parse("00:20"), TimeSpan.Parse("00:30"), TimeSpan.Parse("00:40") } });
                list.Add(new Competitor { Name = "Nelle", Sname = "Butterfield", Laps = new List<TimeSpan> { TimeSpan.Parse("00:10"), TimeSpan.Parse("00:20"), TimeSpan.Parse("00:30"), TimeSpan.Parse("00:40"), TimeSpan.Parse("00:50") } });
                list.Add(new Competitor { Name = "Marc", Sname = "Soriano", Laps = new List<TimeSpan> { TimeSpan.Parse("00:10"), TimeSpan.Parse("00:20") } });
                list.Add(new Competitor { Name = "Cathi", Sname = "Stumpff", Laps = new List<TimeSpan> { TimeSpan.Parse("00:10"), TimeSpan.Parse("00:20"), TimeSpan.Parse("00:30") } });
                list.Add(new Competitor { Name = "Jefferey", Sname = "Hunziker", Laps = new List<TimeSpan> { TimeSpan.Parse("00:10"), TimeSpan.Parse("00:20"), TimeSpan.Parse("00:30") } });
                list.Add(new Competitor { Name = "Berniece", Sname = "Courtney", Laps = new List<TimeSpan> { TimeSpan.Parse("00:10"), TimeSpan.Parse("00:20"), TimeSpan.Parse("00:30") } });
                
                var LapsCounter = list.Select(w => w.Laps.Count).Max();
    
                List<string> listH = new List<string>();
                for (int i = 1; i <= LapsCounter; i++)
                {
                    listH.Add("Lap" + i);
                }
                Mylist.ItemsSource = list;
                ListHeader.ItemsSource = listH;
    
            }
    
            public class Competitor
            {
                public string Name { get; set; }
                public string Sname { get; set; }
                public List<TimeSpan> Laps { get; set; }
            }
