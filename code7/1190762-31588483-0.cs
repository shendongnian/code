        private async void DoSomethingAmazing()
        {
            _Result = await DoSomethingAsync();
            foreach (var item in _Result)
            {
                Debug.WriteLine(item);
            }
        }
