     public override Task OnNavigatingFromAsync(NavigatingEventArgs args)
            {
                args.Cancel = true;
    
                ContentDialog dlg = new ContentDialog()
                {
                    Title = "Bad",
                    Content = "no no no!",
                    PrimaryButtonText = "OK",
                    SecondaryButtonText = "NO"
                };
                dlg.ShowAsync();
    
                return Task.CompletedTask;
            }
