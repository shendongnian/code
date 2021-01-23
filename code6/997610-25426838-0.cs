    public class Data
    {
        public String Name
        {
            get;
            set;
        }
        public DateTime TimeStamp
        {
            get;
            set;
        }
        public Data(String name, DateTime timeStamp)
        {
            this.Name = name;
            this.TimeStamp = timeStamp;
        }
        public override string ToString()
        {
            return String.Format("{0} at {1}", this.Name, this.TimeStamp);
        }
    }
