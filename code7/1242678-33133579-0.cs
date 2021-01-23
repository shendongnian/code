    using System;
    using System.Collections.Generic;
    
    namespace RandomTools
    {
        public class NonRepeatingRandom
        {
            private Random _random;
            private List<int> _possibleValues;
    
            public NonRepeatingRandom(int minValue, int maxValue)
            {
                _random = new Random();
                _possibleValues = new List<int>();
    
                for (var i = minValue; i < maxValue; i++)
                {
                    _possibleValues.Add(i);
                }
            }
    
            public int Next()
            {
                var possibleValuesCount = _possibleValues.Count;
                if (possibleValuesCount == 0)
                {
                    return -1;
                }
    
                var nextIndex = _random.Next(0, possibleValuesCount);
                var nextValue = _possibleValues[nextIndex];
                _possibleValues.RemoveAt(nextIndex);
    
                return nextValue;
            }
        }
    }
