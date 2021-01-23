    public class MyViewModel
    {
        public PointCollection MyPointCollection1 { get; set; }
        public PointCollection MyPointCollection2 { get; set; }
        public MyViewModel()
        {
            MyPointCollection1 = new PointCollection();
            MyPointCollection2 = new PointCollection();
        }
    }
