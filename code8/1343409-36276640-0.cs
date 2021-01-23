    class ConsumerClass // the one which uses DataClass objects
    {
        // All the Mappings required by this consumer class
        readonly Dictionary<Type, Action<DataClass>> InitMap = new Dictionary<Type, Action<DataClass>>();
        readonly Dictionary<Type, Action<DataClass>> DoSomethingAMap = new Dictionary<Type, Action<DataClass>>();
        readonly Dictionary<Type, Action<DataClass>> DoSomethingBMap = new Dictionary<Type, Action<DataClass>>();
        // Constructor
        public ConsumerClass()
        {
            // Initialize all the mappings for all the required types for this consumer class here. 
            // This is a one time overhead, but will definitely speedup the methods within this class
            // You could move this part further up the hierarchy of inheritance, to avoid repetitions in every other consumer class.
            // For int
            InitMap.Add(typeof(int), data => InitWith(data, -1));
            DoSomethingAMap.Add(typeof(int), DoSomethingA<int>);
            DoSomethingBMap.Add(typeof(int), DoSomethingB<int>);
            // For double
            InitMap.Add(typeof(double), data => InitWith(data, -9.99d));
            DoSomethingAMap.Add(typeof(double), DoSomethingA<double>);
            DoSomethingBMap.Add(typeof(double), DoSomethingB<double>);
            // other types, if needed by this consumer
        }
        void InitValues(DataClass data)
        {
            // This takes care of your if s
            InitMap[data.ValueType].Invoke(data);
        }
        void InitWith<T>(DataClass data, T defaultValue)
        {
            // much faster
            var array = (T[])data.GetValues();
            for (var i = 0; i < array.Length; i++)
                array[i] = defaultValue;
        }
        void DoSomethingA(DataClass data)
        {
            DoSomethingAMap[data.ValueType].Invoke(data);
        }
        void DoSomethingA<T>(DataClass data)
        {
            var array = (T[])data.GetValues();
            // do something
        }
        void DoSomethingB(DataClass data)
        {
            DoSomethingBMap[data.ValueType].Invoke(data);
        }
        void DoSomethingB<T>(DataClass data)
        {
            var array = (T[])data.GetValues();
            // do something
        }
    }
