    public class AllData
    {
       public int diff { get; set; }
       public string myEvent {get;set;}
    }
    
    public class YourClass{
             List<AllData> daysLeft {get; set;}
        
             private void AddDataToListView(object sender, RoutedEventArgs e)
                {
                    daysleft = new List<AllData>();
        
                    ReadAllData alldata = new ReadAllData();
                    DB_DaysLeft = alldata.GetAllDays();
                    foreach (var Date in DB_DaysLeft)
                    {
                        AllData ad = new AllData();
                        DateTime dt = Convert.ToDateTime(Date);
        
                        TimeSpan diff = DateTime.Now - Date.Date;
                        int days = (int)Math.Abs(Math.Round(diff.TotalDays));
        
        
                       ad.diff = days;
                       ad.myEvent = events;
                        daysleft.Add(ad);
                    }
                    DaysLeftListView.ItemsSource = DB_DaysLeft.OrderByDescending(i => i.Id).ToList();
        
         }
    }
   
