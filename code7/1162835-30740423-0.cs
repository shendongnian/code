                       <DataGridTemplateColumn Header="SecurityAccesses">
                            <DataGridTemplateColumn.CellTemplate>
                                <DataTemplate>
                                    <DataGrid AutoGenerateColumns="False" CanUserAddRows="False" 
    CanUserDeleteRows="False" ItemsSource="{Binding SecurityAccesses}">
                    <DataGrid.Columns>
         <DataGridTextColumn Header="Access" Binding="{Binding Path=Key}" />
                         <ComboBox Margin="4" ItemsSource="{Binding Value,
                    NotifyOnTargetUpdated=True,Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
                                </DataTemplate>
                            </DataGridTemplateColumn.CellTemplate>
                        </DataGridTemplateColumn>
        ...
