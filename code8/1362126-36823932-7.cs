        <StackPanel>
            <DataGrid x:Name="buyer" ItemsSource="{Binding buyer}" SelectionMode="Single" HorizontalAlignment="Left" SelectionUnit="FullRow" IsReadOnly="True" AutoGenerateColumns="False" FrozenColumnCount="1" >
                <DataGrid.Columns>
                    <DataGridTemplateColumn Header="Joining" >
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <CheckBox IsChecked="{Binding IsSelected,UpdateSourceTrigger=PropertyChanged}"/>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                    <DataGridTextColumn Header="ID" Binding="{Binding buy_id}"/>
                    <DataGridTextColumn Header="Name" Binding="{Binding bname}"/>
                    <DataGridTextColumn Header="Number" Binding="{Binding mobileno}"/>
                </DataGrid.Columns>
            </DataGrid>
            <Button Content="Button" Command="{Binding ButtonClickCommand}" CommandParameter="{Binding ElementName=buyer, Path=ItemsSource}" Margin="0,202,0,0"></Button>
        </StackPanel>
