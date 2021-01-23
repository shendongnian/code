    <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Customers}" SelectedItem="
         {Binding SelectedCustomer}">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding Name, Mode=OneTime}" />
            <DataGridTextColumn Binding="{Binding Address, Mode=OneTime}" />
        </DataGrid.Columns>
    </DataGrid>
