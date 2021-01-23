    public class ChartDataMonthly
    {
        public List<decimal[]> Temperature { get; set; }
    
        public List<decimal[]> Round()
        {
            List<decimal[]> NewTemp = new List<decimal[]>();
            foreach(var t in Temperature)
            {
               t[0] = Math.Round(t[0], 0);
               NewTemp.Add(t)
            }
    
            return NewTemp;
        }
    }
