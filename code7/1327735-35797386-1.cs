    public interface IMeasurement
    {
        SomeType MeasureAll();
    }
    public class MyMeasurement
    {
        // declare Measurement here?  some other context?
        public SomeType MeasureAll()
        {
            return Measurement.MeasureAll();
        }
    }
