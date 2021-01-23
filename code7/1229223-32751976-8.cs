        protected void Page_Load(object sender, EventArgs e)
        {
            MyDataCollection data = new MyDataCollection();
            Chart1.Series[0].Points.DataBind(data, "XValue", "LowWhisker,UpWhisker,LowWBox,UpBox,Average,Median", null);
        }
    
    public class MyDataCollection : List<MyData>
    {
        public MyDataCollection()
        {
            Add(new MyData { XValue = 1, LowWhisker = 10, UpWhisker = 60, LowWBox = 20, UpBox = 50, Average = 30, Median = 40 });
            Add(new MyData { XValue = 2, LowWhisker = 40, UpWhisker = 90, LowWBox = 50, UpBox = 80, Average = 60, Median = 70 });
            Add(new MyData { XValue = 3, LowWhisker = 20, UpWhisker = 70, LowWBox = 30, UpBox = 60, Average = 40, Median = 50 });
        }
    }
    
    public class MyData
    {
        public double XValue { get; set; }
        public double LowWhisker { get; set; }
        public double UpWhisker { get; set; }
        public double LowWBox { get; set; }
        public double UpBox { get; set; }
        public double Average { get; set; }
        public double Median { get; set; }
    }
