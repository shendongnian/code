    this.WhenActivated(d => {
                d(this.countries.Events()
                    .SelectionChanged
                    .Subscribe(ea => {
                        using (ViewModel.SelectedCountries.SuppressChangeNotifications())
                        {
                            ViewModel.SelectedCountries.RemoveAll(ea.RemovedItems.Cast<Country>());
                            ViewModel.SelectedCountries.AddRange(ea.AddedItems.Cast<Country>());
                        }
                    }));
            });
