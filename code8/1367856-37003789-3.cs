     MainViewModel mainViewModel = new MainViewModel();
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                dictionary.Add("Header1", "Header 1 text");
                dictionary.Add("Header2", "Header 2 text");
    
                mainViewModel.Tabs.Add(new TabViewModel(dictionary)
                {
                    Header = "Header1"
                });
                mainViewModel.Tabs.Add(new TabViewModel(dictionary)
                {
                    Header = "Header2"
                });
    
                this.DataContext = mainViewModel;
