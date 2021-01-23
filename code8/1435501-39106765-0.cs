        public class  Book
        {
            public decimal price;
            public string title;
            public string author;
            public string currency;
        }
        private void ManipulateColumns(DataGrid grid)
        {
            DataGridComboBoxColumn currencies = new DataGridComboBoxColumn();
            //Here come the possible choices from the database
            System.Collections.ObjectModel.ObservableCollection<string> allCurrencies = new System.Collections.ObjectModel.ObservableCollection<string>();
            allCurrencies.Add("US");
            allCurrencies.Add("asdf");
            allCurrencies.Add("zzz");
            currencies.ItemsSource = allCurrencies;
            currencies.Header = "Currency";
            currencies.CanUserReorder = false;
            currencies.CanUserResize = false;
            currencies.CanUserSort = false;
            grid.Columns.Add(currencies);
            currencies.MinWidth = 100;
            //Set the selectedItem here for the column "Currency"
            //currencies.
            ((Book)grid.SelectedItem).currency = "US Dollar";
        }
