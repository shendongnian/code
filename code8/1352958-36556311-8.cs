    <Grid>
        <DataGrid Name="DataGrid1" ItemsSource="{Binding Users}">
            <DataGrid.Columns>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Button Command="{Binding DataContext.editButton_Click_Command, ElementName=Base_V}" CommandParameter="{Binding}">Edit</Button>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
    </Window>
