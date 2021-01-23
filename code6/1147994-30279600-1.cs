    public class ObservationData
    {
        public int Adults;
        public int Childs;
        public int TotalWolves
        {
            get { return this.Adults + this.Childs; }
        }
        public ObservationData(int adults, int childs)
        {
            this.Adults = adults;
            this.Childs = childs;
        }
        public ObservationData(string line)
        {
            // Add code here to split data in the line to fill values for adults and childs (and optionally the rest of data)
        }
    }
