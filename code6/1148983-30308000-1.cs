    <DataGrid AutoGenerateColumns="False">
                    <DataGrid.Columns>
                        <DataGridCheckBoxColumn Header="Selected"/>
                        <DataGridTemplateColumn>
                            <DataGridTemplateColumn.CellTemplate>
                                <DataTemplate>
                                    <Button Content="Click Me!" 
                                            Command="{Binding myItemCommand}"/>
                                </DataTemplate>
                            </DataGridTemplateColumn.CellTemplate>
                        </DataGridTemplateColumn>
                        <DataGridTextColumn Header="Task" 
                                            Binding="{Binding TaskText}"/>
                        <DataGridTextColumn Header="Resources" 
                                            Binding="{Binding ResourcesText}"/>
                        <DataGridComboBoxColumn ItemsSource="{Binding AvailableStatuses}" 
                                                SelectedItemBinding="{Binding SelectedStatus}" 
                                                Header="Status" />
                    </DataGrid.Columns>
    <DataGrid.RowDetailsTemplate>
        <DataTemplate>
            <DataGrid ItemsSource="{Binding Resources}">
                <DataGrid.Columns>
                    <DataGridCheckBoxColumn Binding="{Binding IsResourceUsed}"/>
                    <DataGridTextColumn Binding="{Binding ResourceName}"/>
                </DataGrid.Columns>
            </DataGrid>
        </DataTemplate>
    </DataGrid.RowDetailsTemplate>
