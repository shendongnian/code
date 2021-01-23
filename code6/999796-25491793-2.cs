    <DataGrid ItemsSource="{Binding Path=Data}"
                DockPanel.Dock="Top"
                AutoGenerateColumns="False"
                HorizontalContentAlignment="Center"
                HorizontalAlignment="Stretch"
                MouseDoubleClick="DataGrid_DoubleClick"
                Margin="0 0 0 5">
        <DataGrid.Columns>
        <!-- Create a column per value. This can be automated by using a template instead. -->
            <DataGridTemplateColumn Header="{Binding Path=Item}">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <CheckBox IsChecked="{Binding Path=IsSelected,UpdateSourceTrigger=PropertyChanged}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
