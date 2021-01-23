     <DataGrid ItemsSource="{Binding Orders}">
                    <DataGrid.Columns>
                        <DataGridCheckBoxColumn Binding="{Binding IsSelected}">
                            <DataGridCheckBoxColumn.CellStyle>
                            <Style TargetType="DataGridCell">
                                <Setter Property="IsEnabled" Value="{Binding EnableOrder}" />
                            </Style>
                            </DataGridCheckBoxColumn.CellStyle>
                         </DataGridCheckBoxColumn>                
                    </DataGrid.Columns>
        </DataGrid>
