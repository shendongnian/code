    public class Notify
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
    }
    
    public Timer tData = new Timer();
    public List<Notify> Notifications = new List<Notify>();
    
    public void Main()
    {
        // 5 minutes
        tData.Interval = 1000;
        tData.Tick += new EventHandler(CheckEvents);
    }
    
    public void GetAllEvents()
    {
        DataTable results = new DataTable();
        /* results = YourDatabase(Select id, name, event FROM...); */
    
        Notifications.Clear();
    
        foreach(DataRow row in results.Rows)
        {
            Notifications.Add
            (
                new Notify
                {
                    ID = int.Parse(row[0].ToString()),
                    Name = row[1].ToString(),
                    Time = DateTime.Parse(row[2].ToString())
                }
            );
        }
    }
    
    public void CheckEvents(object sender, EventArgs e)
    {
        IEnumerable<Notify> eventsElapsed = Notifications.Where(notify => notify.Time == DateTime.Now);
    
        foreach(Notify notify in eventsElapsed)
        {
            // Send your sms
            var id = notify.ID;
            var name = notify.Name;
            var time = notify.Time;
        }
    }
