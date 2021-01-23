    <ScrollViewer>
        <ScrollViewer.Resources>
            <DataTemplate DataType="{x:Type l:CustomTable}">
                <StackPanel>
                    <ItemsControl ItemsSource="{Binding Path=Main}">
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <DataGrid Name="dg" SelectedItem="{Binding DataContext.SelectedItem, Mode=TwoWay, RelativeSource={RelativeSource FindAncestor,AncestorType=ItemsControl}}"
                                      CanUserAddRows="False"  ItemsSource="{Binding}" AutoGenerateColumns="True" >
                                    <DataGrid.RowDetailsTemplate>
                                        <DataTemplate>
                                            <ContentControl Margin="10"
                                                            Content="{Binding DataContext.Child, RelativeSource={RelativeSource FindAncestor,AncestorType=ItemsControl,AncestorLevel=2}}"/>
                                        </DataTemplate>
                                    </DataGrid.RowDetailsTemplate>
                                </DataGrid>
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                </StackPanel>
            </DataTemplate>
        </ScrollViewer.Resources>
        <ContentControl Content="{Binding TableCollection}"/>
    </ScrollViewer>
