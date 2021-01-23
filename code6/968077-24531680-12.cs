    public class MyChart: Chart
    {
        public void MyMethod() 
        {
            MySeries mySeries = (MySeries)this.Series[0];
            mySeries.MySeriesMethod();
        }
    }
