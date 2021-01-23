    <DataGrid ItemsSource="{Binding Items}">
        <DataGrid.Resources>
            <stackOverflow:DateTimeConverter x:Key="DateTimeConverter"/>
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding LastRunTime, Converter={StaticResource DateTimeConverter}}" Header="Last Run Time" />
        </DataGrid.Columns>
    </DataGrid>
