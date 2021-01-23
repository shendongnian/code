      public Task<string> GetLoginCode()
                {
        
                    return Task.Run(() =>
                    {
                        CodeRequestViewModel viewModel = new CodeRequestViewModel();
                        Application.Current.Dispatcher.Invoke(delegate 
                        {
                            CodeRequestView view = new CodeRequestView();
                            view.ShowDialog();
                        });
                        return viewModel.Code;
                    });
                }
