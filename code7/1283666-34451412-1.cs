     protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string parameter = this.NavigationContext.QueryString["parameter"];
            Vegetable vegeItem = null;
            int VegeId = -1;
            if (int.TryParse(parameter, out VegeId))
            {
                Debug.WriteLine(VegeId);
                vegeItem = App.ViewModel.VegeItems.FirstOrDefault(c => c.ID == VegeId);
                DataContext = vegeItem;
            }
        }  
