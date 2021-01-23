    <ScrollViewer>
        <ScrollViewer.Resources>
            <DataTemplate DataType="{x:Type l:CustomTable}">
                <StackPanel>
                    <ItemsControl ItemsSource="{Binding Path=Main}">
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <DataGrid SelectedItem="{Binding DataContext.SelectedItem, Mode=TwoWay, RelativeSource={RelativeSource FindAncestor,AncestorType=ItemsControl}}"
                                          CanUserAddRows="False"  ItemsSource="{Binding}" AutoGenerateColumns="True" />
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                    <Expander Header="Child" Margin="10" IsExpanded="True" x:Name="child">
                        <ContentControl Content="{Binding Child}"/>
                    </Expander>
                </StackPanel>
                <DataTemplate.Triggers>
                    <DataTrigger Binding="{Binding Child}" Value="{x:Null}">
                        <Setter TargetName="child" Property="Visibility" Value="Collapsed"/>
                    </DataTrigger>
                </DataTemplate.Triggers>
            </DataTemplate>
        </ScrollViewer.Resources>
        <ContentControl Content="{Binding TableCollection}"/>
    </ScrollViewer>
