    public class SomeClass
    {
        private Measurement TheMeasurement { get; set; }
        public SomeClass(Measurement theMeasurement)
        {
            TheMeasurement = theMeasurement;
        }
        public void MethodBeingTested()
        {
            // use TheMeasurement here
        }
    }
