    <DataGrid ItemsSource="{Binding myCollection}" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Header="First Name" Binding="{Binding FirstName}" />
            <DataGridTextColumn Header="Middle Name" Binding="{Binding MiddleName}" />
            <DataGridTextColumn Header="Last Name" Binding="{Binding LastName}" />
            <DataGridTemplateColumn>
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <ListBox ItemsSource="{Binding Things}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
