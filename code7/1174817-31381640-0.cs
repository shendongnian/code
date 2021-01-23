    <Grid>
        <DataGrid x:Name="dg" HorizontalAlignment="Left" Margin="10,10,0,0" VerticalAlignment="Top" Height="299" AutoGenerateColumns="False" Width="497" AddingNewItem="dg_AddingNewItem" CanUserAddRows="True">
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="DateWorks">
                    <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <DatePicker SelectedDate="{Binding InvoiceDate,
                                                               UpdateSourceTrigger=PropertyChanged}" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
                <DataGridTemplateColumn Header="DateDoesn'tWork">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <DatePicker IsHitTestVisible="False" 
                                        SelectedDate="{Binding InvoiceDate,
                                                               UpdateSourceTrigger=PropertyChanged}" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                    <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <DatePicker SelectedDate="{Binding InvoiceDate, 
                                                               UpdateSourceTrigger=PropertyChanged}" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
                <DataGridTextColumn Header="Text" Binding="{Binding Description, 
                                                                    UpdateSourceTrigger=PropertyChanged}"/>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
