    <DataGrid x:Name="MasterGrid" Grid.ColumnSpan="2" ItemsSource="{Binding Categories}" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn  Width="SizeToHeader" Header="Category Id" Binding="{Binding Path = CategoryId}"/>
            <DataGridTextColumn  Width="SizeToHeader" Header="Name" Binding="{Binding Path = Name}"/>
        </DataGrid.Columns>
    </DataGrid>
    <DataGrid DataContext="{Binding SelectedItem, ElementName=MasterGrid}" Grid.ColumnSpan="2" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn  Binding="{Binding CategoryId}" Header="Category Id" Width="SizeToHeader"/>
            <DataGridTextColumn Binding="{Binding Name}" Header="Name" Width="SizeToHeader"/>
            <DataGridTextColumn  Binding="{Binding ProductId}" Header="Product Id" Width="SizeToHeader"/>
        </DataGrid.Columns>
    </DataGrid>
