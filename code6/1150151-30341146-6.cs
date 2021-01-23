    public class YourClass{
     List<int> daysLeft {get; set;}
    
     private void AddDataToListView(object sender, RoutedEventArgs e)
        {
           daysLeft = new List<int>();
            ReadAllData alldata = new ReadAllData();
            DB_DaysLeft = alldata.GetAllDays();     
            foreach(days in DB_Days_Lefy)
            {
                 daysLeft.add(dateTime.Now.Subtract(days).TotalDays());
            }    
        }
    }
