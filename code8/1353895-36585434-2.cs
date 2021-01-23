    public class DataPoint
    {
      public DateTime Date { get; set; }
      public double Val1 { get; set; }
      public double Val2 { get; set; }
    }
    
    // ... your other code ...
    
    var dataSource = new List<DataPoint>();
    for (int i = 0; i < ch.spotsList[0].Date.Count; i++)
    {
      dataSource.Add(new DataPoint() 
      { 
        Date = ch.spotsList[0].Date[i],
        Val1 = ch.spotsList[0].Val1[i],
        Val2 = ch.spotsList[0].Val2[i]
      });
    }
    dataGridView1.DataSource = dataSource;
