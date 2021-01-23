    public class RowViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        // INPC implementation is omitted
        public string Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }
        private string id;
        public string this[string columnName]
        {
            get
            {
                if (string.IsNullOrEmpty(Id))
                {
                    return "Id cannot be an empty string.";
                }
                return null;
            }
        }
        public string Error
        {
            get { return null; }
        }
    }
        <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Rows}">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Id" Binding="{Binding Id, ValidatesOnDataErrors=True, UpdateSourceTrigger=PropertyChanged}"/>
            </DataGrid.Columns>
        </DataGrid>
