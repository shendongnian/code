    public class FakeClass
    {
        private double func1Result;
        private double func2Result;
        private double func3Result;
        public FakeClass()
        {
            func1Result = Double.MinValue;
            func2Result = Double.MinValue;
            func3Result = Double.MinValue;
            _property1 = Double.MinValue;
            _property2 = Double.MinValue;
            _neededObject = null;
        }
        private double _property1;
        public double Property1
        {
            get { return _property1; }
            set
            {
                if (_property1 != value)
                {
                    _property1 = value;
                    RecalculateFunc1Result();
                }
            }
        }
        private double _property2;
        public double Property2
        {
            get { return _property2; }
            set
            {
                if (_property2 != value)
                {
                    _property2 = value;
                    RecalculateFunc2Result();
                }
            }
        }
        private static FakeObject _neededObject;
        public FakeObject Needed
        {
            get { return _neededObject; }
            set
            {
                if (_neededObject != value)
                {
                    _neededObject = value;
                    RecalculateFunc3Result();
                }
            }
        }
        private double RecalculateFunc1Result()
        {
            // Check to make sure the values are not the default/invalid ones.
            if (_property1 == Double.MinValue ||
                _property2 == Double.MinValue)
            {
                func1Result = Double.MinValue;
                return func1Result;
            }
            //func1Result = Lengthy calculation involing some properties.
            return func1Result;
        }
        private double RecalculateFunc2Result()
        {
            // Check to make sure the values are not the default/invalid ones.
            if (_property1 == Double.MinValue ||
                _property2 == Double.MinValue)
            {
                func2Result = Double.MinValue;
                return func2Result;
            }
            //func2Result = Lengthy calculation involing some properties and 
            //   RecalculateFunc1Result() or func1Result.
            return func2Result;
        }
        private double RecalculateFunc3Result()
        {
            if (Needed == null)
                throw new InvalidOperationException(
                    @"The ""Needed"" object is necessary to perform this calculation.");
            //func3Result = Lengthy calculation involving RecalculateFunc1Result()
            //   or func1Result
            return func3Result;
        }
    }
