    public class DialogViewModel
    {
        // other code here
        public ObservableCollection<DataRowViewModel> DataRows
        {
            get { return dataRows ?? (dataRows = new ObservableCollection<DataRowViewModel>(yourStringList.Select(s => new DataRowViewModel { Text = s }))); }
        }
        private ObservableCollection<DataRowViewModel> dataRows;
    }
