    class Counter
    {
        public delegate void IndexValueChangedEventHandler(object sender, IndexValueChangedEventArgs e);
        public event IndexValueChangedEventHandler IndexValueChanged;
        int _maxNumber;
        int _index;
        public Counter(int maxNumber)
        {
            _maxNumber = maxNumber;
        }
        public async void StartCountAsync()
        {
            AsyncOperation asyncCountOperation = AsyncOperationManager.CreateOperation(null);
            await Task.Run(() =>
            {
                for (int i = 0; i < _maxNumber; i++)
                {
                    _index = i;
                    asyncCountOperation.Post(new SendOrPostCallback(InvokeDelegate), _index);
                    Thread.Sleep(100);
                }
            });
        }
        private void InvokeDelegate(object index)
        {
            if (IndexValueChanged != null)
            {
                IndexValueChanged(this, new IndexValueChangedEventArgs((int)index));
            }
        }
    }
