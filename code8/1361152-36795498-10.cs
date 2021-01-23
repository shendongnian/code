    <DataGrid 
        Name="getEmployees" 
        AutoGenerateColumns="False"
        >
        <DataGrid.Columns>
            <DataGridCheckBoxColumn 
                Binding="{Binding enabled}"
                Header="Enabled"
                />
            <DataGridTextColumn 
                Binding="{Binding proxyFor}"
                Header="Proxy For"
                />
        </DataGrid.Columns>
    </DataGrid>
