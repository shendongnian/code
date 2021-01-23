    DispatcherTimer timer =
        new DispatcherTimer(TimeSpan.FromMilliseconds(10),
                        DispatcherPriority.Normal,
                        delegate
                        {
                            MyCustomLabel.SetValue(MaxRangeProperty, viewModel.Range);
                        },
                        Dispatcher);
