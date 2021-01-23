        public async Task<bool> ShowDialogAsync(string title, string message, string acceptMessage, string cancelMessage)
                    {
                        Grid ShowDialogMessage = null;
                        Grid CurrentPageGrid = (App.Instance.CurrentPage as ContentPage).Content as Grid;
                        TaskCompletionSource<bool> result = new TaskCompletionSource<bool>();
                        try
                        {
                            ShowDialogMessage = GenericView.CustomDisplayAlert(message, CurrentPageGrid.RowDefinitions.Count, CurrentPageGrid.ColumnDefinitions.Count, () =>
                            {
             //here you can add your implementation   
                                CurrentPageGrid.Children.Remove(ShowDialogMessage);
                            
      result.SetResult(true);
            
                            },
                            () =>
                            {
             //here you can add your implementation      
                                CurrentPageGrid.Children.Remove(ShowDialogMessage);
                                result.SetResult(false);
                            }, title, acceptMessage, cancelMessage);
            
                            CurrentPageGrid.Children.Add(ShowDialogMessage);
                            return await result.Task;
                        }
                        catch (Exception ex)
                        {
                            return await App.Current.MainPage.DisplayAlert(title, message, acceptMessage, cancelMessage);
            #if DEBUG
                            throw ex;
            #endif
                        }
            
                    }
