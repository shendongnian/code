    class SensorData {
        public IList<float> Values {get;}
        public SensorData(IEnumerable<float> values) {
            Values = values.ToList();
        }
        // Add some useful methods that operate on Values here
        ...
    }
