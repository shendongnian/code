    Task.Factory.StartNew(async () =>
                    {
                        ObservableCollection<ItemValue> children = new ObservableCollection<ItemValue>(await _model.Dispatcher.InvokeAsync<IEnumerable<ItemValue>>(() => _model.GetItems(node)));
                        // fill some control
                    });
