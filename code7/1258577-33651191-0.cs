    public class Chiller
    {
        private MyGeneralInformation information;
        public MyGeneralInformation GeneralInformation
        {
            get
            {
                return information;
            }
            set
            {
                information = value;
                information.parent = this;
            }
        }
        public MyController Controller { get; set; }
        public class MyGeneralInformation
        {
            internal Chiller parent;
            public string AssemblyID { get; set; }
            public string PrimaryVoltage
            {
                get
                {
                    return string.Format(
                        "{0}/{1}",
                        parent.Controller.PrimaryVoltage.Voltage,
                        parent.Controller.PrimaryVoltage.Phases);
                }
            }
        }
        public class MyController
        {
            public MyPrimaryVoltage PrimaryVoltage { get; set; }
            public class MyPrimaryVoltage
            {
                public string Voltage { get; set; }
                public string Phases { get; set; }
            }
        }
    }
