        <DataGrid ItemsSource="{Binding Items}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="X" Binding="{Binding X}"/>
                <DataGridTextColumn Header="Y" Binding="{Binding Y}">
                    <DataGridTextColumn.CellStyle>
                        <Style TargetType="DataGridCell">
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding X}" Value="3">
                                    <Setter Property="IsEnabled" Value="False"/>
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </DataGridTextColumn.CellStyle>
                </DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
