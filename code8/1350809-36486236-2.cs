    <DataGrid ItemsSource="{Binding Rows}" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding Number}">
                <DataGridTextColumn.CellStyle>
                    <Style TargetType="{x:Type DataGridCell}">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding Number}" Value="3">
                                <Setter Property="Background">
                                    <Setter.Value>
                                        <SolidColorBrush Color="Green"/>
                                    </Setter.Value>
                                </Setter>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </DataGridTextColumn.CellStyle>
            </DataGridTextColumn>
        </DataGrid.Columns>
    </DataGrid>
