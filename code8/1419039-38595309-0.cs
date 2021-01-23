     <Grid Margin="10">
            <DataGrid Name="dgRecords" ItemsSource="{Binding Records}" AutoGenerateColumns="False">
                <DataGrid.Columns>
                    <DataGridTemplateColumn Header="Number">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <ComboBox
                                IsEditable="True"
                                Width="120"
                                ItemsSource="{Binding DataContext.Items, ElementName=dgRecords}"
                                SelectedItem="{Binding SelectedItem}"
                                Text="{Binding NewItem, UpdateSourceTrigger=LostFocus}"/>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
        </Grid>
