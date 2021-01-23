    public sealed class MovingAverage
    {
        private readonly int _max;
        private readonly double[] _numbers;
        private double _total;
        private int _front;
        private int _count;
        public MovingAverage(int max)
        {
            _max = max;
            _numbers = new double[max];
        }
        public double Average
        {
            get { return _total / _count; }
        }
        public void Add(double value)
        {
            _total += value;
            if (_count == _max)
                _total -= _numbers[_front];
            else
                ++_count;
            _numbers[_front] = value;
            _front = (_front+1)%_max;
        }
    };
