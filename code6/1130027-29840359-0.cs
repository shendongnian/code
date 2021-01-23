     public class Aroon 
    {  
        public bool AroonDown
        {
            get;
            set;
        }
    	public double Period
        {
            get;
            set;
        }
        public Aroon()
        {
        }
        public IList<double> Execute(IList<double> src)
        {
            if (!this.AroonDown)
            {
                return this.ExecuteUp(src);
            }
            return this.ExecuteDown(src);
        }
        public IList<double> ExecuteDown(IList<double> src)
        {
            double[] period = new double[src.Count];
            for (int i = 1; i < src.Count; i++)
            {
                double num = LowestBarNum(src, i, Period);
                period[i] = 100 * (Period - num) / Period;
            }
            return period;
        }
        public IList<double> ExecuteUp(IList<double> src)
        {
            double[] period = new double[src.Count];
            for (int i = 1; i < src.Count; i++)
            {
                double num = HighestBarNum(src, i, Period);
                period[i] = 100 * ((Period - num) / Period;
            }
            return period;
        }}
