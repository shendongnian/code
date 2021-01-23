    public class YourView
    {
        private List<Fouten> loadedData;
        public void LoadData(...)
        {
            DateTime dateStart = CalenderSearch.SelectedDates.First();
            DateTime dateEnd = CalenderSearch.SelectedDates.Last();
            
            ObjectQuery<Fouten> fouten = eventsEntities.Foutens;
            
            // here you save unfiltered data to the field and then you can use it to filter collection
            loadedData = ...;
            
            if (loadedData.Count == 0)
                foutensDataGrid.ItemsSource = null;
            else
                foutensDataGrid.ItemsSource = loadedData;
        }
        
        private void FilterByFoutCodeButtonClick(object sender, EventArgs e)
        {
            var filter = FoutCodeTextBox.Content.ToString();
            if(!string.IsNullOrEmpty(filter))
            {
                // if your filter is not empty then filter loadedData by criteria 
                foutensDataGrid.ItemsSource = loadedData.Where(x => x.FoutCode == filter);
            }
        }
    }
