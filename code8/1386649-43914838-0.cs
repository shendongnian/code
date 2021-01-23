    <DataGrid IsReadOnly="True">
        <DataGrid.Columns>
            <DataGridCheckBoxColumn Header="Test" IsReadOnly="True" Binding="{Binding MyBinding}">
                <DataGridCheckBoxColumn.ElementStyle>
                    <Style BasedOn="{x:Static DataGridCheckBoxColumn.DefaultElementStyle}">
                        <Setter Property="FrameworkElement.Margin" Value="0,1,0,0" />
                        <Setter Property="FrameworkElement.VerticalAlignment" Value="Center" />
                        <Setter Property="FrameworkElement.HorizontalAlignment" Value="Center" />
                    </Style>
                </DataGridCheckBoxColumn.ElementStyle>
            </DataGridCheckBoxColumn>
        </DataGrid.Columns>
    </DataGrid>
