    <DataGrid Name="gridDetails"  AutoGenerateColumns="False" ItemsSource="{Binding Orders}">
        <DataGrid.Columns>
             <DataGridTextColumn Header="Item Name" Width="150">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                       <TreeView>
                            <TreeViewItem ItemsSource="{Binding ItemAdditionals}">
                                <TreeViewItem.Header>
                                    <TextBlock Text="{Binding itemName}" TextWrapping="Wrap" TextAlignment="Center"/>
                                </TreeViewItem.Header>
                                <TreeViewItem.ItemTemplate>
                                    <DataTemplate>
                                        <TextBlock Margin="10 0 0 0" Text="{Binding}"/>
                                    </DataTemplate>
                                </TreeViewItem.ItemTemplate>
                            </TreeViewItem>
                        </TreeView>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTextColumn>                     
            <DataGridTextColumn Header="Quantity" Binding="{Binding quantity}" />
            <DataGridTextColumn Header="Price" Binding="{Binding itemPrice}" />
        </DataGrid.Columns> 
    </DataGrid>
