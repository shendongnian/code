     public void FilterSite()
        {
         listofsites = new observablecollection<Site Details> 
            
    if (SelectedItem.Contains("EC350"))
    
                Listofsites = new ObservableCollection<SiteDetails>(listofsites.Where(p => Convert.ToString(p.DeviceType) == "MiCell_Ec350"));
            else if (SelectedItem.Contains("MiCell"))
                Listofsites = new ObservableCollection<SiteDetails>(listofsites.Where(p => Convert.ToString(p.DeviceType) == "MiCell"));
            else if (SelectedItem.Contains("Mini-Max"))
                Listofsites = new ObservableCollection<SiteDetails>(listofsites.Where(p => Convert.ToString(p.DeviceType) == "Mini-Max"));
    
    
        }
