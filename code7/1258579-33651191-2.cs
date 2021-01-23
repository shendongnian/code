    public class Chiller
    {
        public string AssemblyID { get; set; }
        public string PrimaryVoltage
        {
            get
            {
                return string.Format("{0}/{1}", Voltage, Phases);
            }
        }
        public string Voltage { get; set; }
        public string Phases { get; set; }
    }
