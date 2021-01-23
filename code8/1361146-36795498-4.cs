    <DataGrid 
        Name="getEmployees" 
        AutoGenerateColumns="False"
        >
        <DataGrid.Columns>
            <DataGridCheckBoxColumn 
                Binding="{Binding enabled}"
                />
            <DataGridTextColumn 
                Binding="{Binding proxyFor}"
                />
        </DataGrid.Columns>
    </DataGrid>
