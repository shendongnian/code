        <DataGrid ItemsSource="{Binding ViewModel.MyList}" 
                  AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}" CellStyle="{StaticResource CellDefaultStyle}" />
                <DataGridTemplateColumn Header="Weight" 
                                        CellStyle="{StaticResource CellDefaultStyle}">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Path=Weight}" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                    <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <TextBox Text="{Binding Path=Weight}" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
                <DataGridTextColumn Header="Created At" Binding="{Binding CreatedAt}" CellStyle="{StaticResource CellReadOnlyStyle}"/>
            </DataGrid.Columns>
        </DataGrid>
