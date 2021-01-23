    public ICommand ItemSelected
            {
                get
                {
                    return new Template10.Mvvm.DelegateCommand<string>((s) =>
                     {
                         NavigationService.Navigate(typeof(DetailPage), s);
                         
                     });
                }
                
            }
