     private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                Parameters = new ObservableCollection<ParamaterClass>();
                Parameters.CollectionChanged += Parameters_CollectionChanged;
                ParamaterClass ParamaterClass = new ParamaterClass();
                ParamaterClass.Key = "Test1Key";
                ParamaterClass.Value = "Test1Value";
                ParamaterClass.IsPostParameter = true;
    
                Parameters.Add(ParamaterClass);
            }
    
            void Parameters_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                int count = Parameters.Count;
            }
