        public double AccurateAverage()
        {
            double total = 0;
            for (int i = 0, j = _front; i < _count; ++i)
            {
                total += _numbers[j];
                if (--j < 0)
                    j = _max - 1;
            }
            return total/_count;
        }
