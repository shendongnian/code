    public class DataPoint
    {
        public int sr {get; internal set;}
        public int id {get; internal set;}
        public int Result {get {return sr * id;}}
        public DataPoint (int sr, int id)
        {
            this.sr = sr;
            this.id = id;
        }
    }
    
    ObservableCollection<DataPoint> MyData = new ObservableCollection<DataPoint>();
    MyData.Add (new DataPoint(1, 10));
    MyData.Add (new DataPoint(2, 20));
    MyData.Add (new DataPoint(3, 30));
    MyData.Add (new DataPoint(4, 40));
    MyData.Add (new DataPoint(5, 50));
