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
                            <TextBlock Text="{Binding Amount, UpdateSourceTrigger=PropertyChanged}">
                        </TextBlock>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
                    <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <TextBox Text="{Binding Amount, UpdateSourceTrigger=PropertyChanged}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
    public class ItemOpeningBalanceRow : INotifyPropertyChanged
    {
        private double _quantity;
        private double _rate;
        private double _amount;
        public double Quantity
        {
            get { return _quantity; }
            set 
            { 
                _quantity = value; 
                OnPropertyChanged();
                Amount = Quantity*Rate;
            }
        }
        public double Rate {
            get { return _rate; }
            set
            {
                if (!(Math.Abs(_rate - value) > 0.0001)) return;
                _rate = value;
                OnPropertyChanged();
                Amount = Quantity * Rate;
            }
        }
        public double Amount
        {
            get { return Quantity*Rate; }
            set
            {
                if (!(Math.Abs(_amount - value) > 0.0001)) return;
                _amount = value;
                OnPropertyChanged();
                Rate = _amount / Quantity;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
