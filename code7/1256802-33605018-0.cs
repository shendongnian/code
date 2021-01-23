    public async void StartCountAsync()
    {
        for (int i = 0; i < _maxNumber; i++)
        {
            _index = i;
            if (IndexValueChanged != null)
                IndexValueChanged(this, new IndexValueChangedEventArgs(_index));
            await Task.Delay(100);
        }
    }
