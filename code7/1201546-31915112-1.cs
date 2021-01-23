    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        <DataGrid Grid.Row="0" AutoGenerateColumns="False"
              ItemsSource="{Binding Orders}" 
              SelectedItem="{Binding SelectedOrder}">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Item ID" Binding="{Binding Id}" />
            <DataGridTextColumn Header="Item Name" Binding="{Binding Name}" />
            <DataGridTemplateColumn Header="Addtionals">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                            <ItemsControl ItemsSource="{Binding Additionals}">
                                <ItemsControl.ItemTemplate>
                                    <DataTemplate>
                                        <TextBlock Text="{Binding}"/>
                                    </DataTemplate>
                                </ItemsControl.ItemTemplate>
                            </ItemsControl>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
            <DataGridTextColumn Header="Quantity" Binding="{Binding Quantity}" />
            <DataGridTextColumn Header="Item Price" Binding="{Binding Price}" />
        </DataGrid.Columns>
    </DataGrid>
    <Button  Grid.Row="1" Content="New Order" Click="Order_Click"/>
    </Grid>
