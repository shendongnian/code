        <Grid>
        <DataGrid ItemsSource="{Binding Strings}" AutoGenerateColumns="False" >
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="String" Width="60" IsReadOnly="True">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Button Content="{Binding }" HorizontalAlignment="Stretch" VerticalAlignment="Stretch"
                                    Command="{Binding RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}, Path=DataContext.Command}"
                                    CommandParameter="{Binding RelativeSource={RelativeSource Self}, Path=Content}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid></Grid>
