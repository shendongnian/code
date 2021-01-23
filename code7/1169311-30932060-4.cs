    var task = Task.Factory.StartNew(() =>
            {
                if (_viewModel == null)
                {
                    _viewModel = new MainViewModel();
                }
            }).
                ContinueWith(x =>
                {
                    labelLoading.Text = "Creando orden...";
                    labelLoading.Visible = true;
                    Models.FirstPhaseModel model = new Models.FirstPhaseModel()
                    {
                        // Set data.
                    };
                    orderNumberLabel.Text = _viewModel.FirstPhase(model);
                    firstPhaseBtn.Enabled = true;
                    labelLoading.Text = string.Empty;
                    labelLoading.Visible = false;
                }, TaskScheduler.Current).ContinueWith(result =>
                {
                    if (result.IsFaulted)
                    {
                        // do something with the result and "consume" it.
                        _log.Error(result.Exception);
                    }
                });
