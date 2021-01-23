    <DataGrid ItemsSource="{Binding Users}" AutoGenerateColumns="False" CanUserAddRows="false">
        <DataGrid.Columns>
            <DataGridCheckBoxColumn Binding="{Binding IsSelected, Mode=TwoWay}" />
            <DataGridTextColumn Binding="{Binding Id}" />
            <DataGridTextColumn Binding="{Binding Name}" />
        </DataGrid.Columns>
    
    </DataGrid>
