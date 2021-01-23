    <DataGrid x:Name="dataGrid1" AutoGenerateColumns="False">
        <DataGrid.CommandBindings>
            <CommandBinding Command="ApplicationCommands.Copy" Executed="DatagridExecuted" />
        </DataGrid.CommandBindings>
        <DataGrid.Columns>
          ...
        </DataGrid.Columns>
    </DataGrid>
