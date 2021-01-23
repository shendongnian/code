    <DataGrid ItemsSource="{Binding OpeningBalances}" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="Quantity" >
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Quantity, UpdateSourceTrigger=PropertyChanged}"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
                <DataGridTemplateColumn.CellEditingTemplate>
                    <DataTemplate>
                        <TextBox Text="{Binding Quantity, UpdateSourceTrigger=PropertyChanged}"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellEditingTemplate>
            </DataGridTemplateColumn>
            <DataGridTemplateColumn Header="Rate" >
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Rate, UpdateSourceTrigger=PropertyChanged}"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
                <DataGridTemplateColumn.CellEditingTemplate>
                    <DataTemplate>
                        <TextBox Text="{Binding Rate, UpdateSourceTrigger=PropertyChanged}"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellEditingTemplate>
            </DataGridTemplateColumn>
            <DataGridTemplateColumn Header="Amount" >
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Amount}">
                        </TextBlock>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
    public class ItemOpeningBalanceRow : INotifyPropertyChanged
    {
        private double _quantity;
        private double _rate;
        public double Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(); OnPropertyChanged("Amount"); }
        }
        public double Rate {
            get { return _rate; }
            set { _rate = value; OnPropertyChanged(); OnPropertyChanged("Amount"); }
        }
        public double Amount
        {
            get { return Quantity*Rate; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
