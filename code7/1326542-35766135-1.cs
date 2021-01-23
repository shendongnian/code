    public class YourView
    {
        private List<Fouten> loadedData;
        public void LoadData(...)
        {
            ObjectQuery<Fouten> fouten = eventsEntities.Foutens;
            
            // here you save unfiltered data to the field and then you can use it to filter collection
            loadedData = ...;
            
            // if you want to filter values immediately you can call filter method right here
            // FilterByFoutCode(someValue);
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
                FilterByFoutCode(filter);
            }
        }
        private void FilterByFoutCode(string filter)
        {
            foutensDataGrid.ItemsSource = loadedData.Where(x => x.FoutCode == filter);
        }
    }
