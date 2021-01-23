    <DataGrid x:Name="dataGrid" ItemsSource="{Binding MyCollection}" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridCheckBoxColumn Binding="{Binding IsSelected}" Width="50" >
                <DataGridCheckBoxColumn.HeaderTemplate>
                    <DataTemplate x:Name="dtAllChkBx">
                        <CheckBox Name="cbxAll" DataContext="{Binding ElementName=dataGrid, Path=DataContext}" Command="{Binding MyCommand}" CommandParameter="{Binding Path=IsChecked, RelativeSource={RelativeSource Self}}"/>
                    </DataTemplate>
                </DataGridCheckBoxColumn.HeaderTemplate>
            </DataGridCheckBoxColumn>
            <DataGridTemplateColumn Header="Name" Width="SizeToCells" IsReadOnly="True">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding UsecaseName}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
