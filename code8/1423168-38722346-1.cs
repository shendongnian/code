    var searchObservable = Observable.FromEventPattern(s => box.TextChanged +=  s, s => box.TextChanged -= s)
    .Throttle(TimeSpan.FromMilliseconds(400))
    .Select(result =>
        {
            var textBox = result.Sender as AutoSuggestBox;
            return textBox.Text;
        }
    );
    searchObservable
    .DistinctUntilChanged()
    .ObserveOnDispatcher()
    .Subscribe(searchString =>
        {
              //Select elements from 'AllTags' here, this code will be launched with 400ms delay (throttle) when user is typing fast.
        }
