    using Microsoft.Research.DynamicDataDisplay.DataSources;
    
    public class MyViewModel
        {
            public ObservableDataSource<Point> Data { get; set; }
    
            public MyViewModel()
            {
                Data = new ObservableDataSource<Point>();
            }
        }
