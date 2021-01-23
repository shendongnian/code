    <Grid>
        <StackPanel Orientation="Vertical">
            <DataGrid ItemsSource="{Binding list1}">
                <DataGrid.Columns>
                    <DataGridTemplateColumn Header="ComboCol" Width="50">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <ComboBox Text="Bind Your Combo Box" IsEditable="True"></ComboBox>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                        </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
            <DataGrid ItemsSource="{Binding list2}" HeadersVisibility="None">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="Line1" Binding="{Binding Path=.}" Width="50"/>
                    <DataGridTextColumn Header="Line2" Binding="{Binding Path=.}" Width="50"/>
                </DataGrid.Columns>
            </DataGrid>
            <DataGrid/>
        </StackPanel>
    </Grid>
