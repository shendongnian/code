    var countOfBiggest = -1;
    var indexOfBiggest = -1;
    for (var n = 0; n < _currentHistogram.BucketCount; n++)
    {
        if (_currentHistogram.Item[n].Count > countOfBiggest)
        {
            countOfBiggest = _currentHistogram.Item[n].Count;
            indexOfBiggest = n;
        }
    }
