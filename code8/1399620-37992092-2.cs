    class dayInOutLog
    {
        public string status { get; set; }
        public int inTime { get; set; }
        public int outTime { get; set; }
        public dayInOutLog(string st, int t_1, int t_2)
        {
            this.status = st;
            this.inTime = t_1;
            this.outTime = t_2;
        }
    }
    public class Emp_dayInOutLog
    {
        public string id{ get; set;}
        public List<dayInOutLog>  listOf_inOut { get; set;}
        public Emp_dayInOutLog(string _id)
        {
            this.id = _id;
            this.listOf_inOut = new List<dayInOutLog>();
        }
    }
