    <Grid>
        <DataGrid Name="DataGrid1" AutoGenerateColumns="False" ItemsSource="{Binding items}" >
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="Combobox">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <ComboBox SelectedIndex="0" ItemsSource="{Binding PredictiveAttributeValues}" />
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate> 
                </DataGridTemplateColumn>
                <DataGridTextColumn Binding="{Binding Coll1}" Header="Column 1">
                    <DataGridTextColumn.CellStyle>
                        <Style TargetType="DataGridCell">
                            <Setter Property="Background"  Value="Blue" />
                            <Setter Property="Foreground" Value="White" />
                        </Style>
                    </DataGridTextColumn.CellStyle>
                </DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding Coll2}" Header="Column 2">
                    <DataGridTextColumn.CellStyle>
                        <Style TargetType="DataGridCell">
                            <Setter Property="Background"  Value="Red" />
                            <Setter Property="Foreground" Value="White" />
                        </Style>
                    </DataGridTextColumn.CellStyle>
                </DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
