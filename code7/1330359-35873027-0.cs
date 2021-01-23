    <DataGridTextColumn Header="MyData" Binding="{Binding MyData}">
        <DataGridTextColumn.HeaderStyle>
            <Style TargetType="DataGridColumnHeader" BasedOn="{StaticResource {x:Type DataGridColumnHeader}}">
                <Style.Setters>
                    <Setter Property="Visibility" Value="{Binding IsChecked, ElementName=MyCheckBox, Converter={StaticResource BoolToVisualConvertor}}" />
                </Style.Setters>
            </Style>
        </DataGridTextColumn.HeaderStyle>
        <DataGridTextColumn.CellStyle>
            <Style TargetType="DataGridCell" BasedOn="{StaticResource {x:Type DataGridCell}}">
                <Style.Setters>
                    <Setter Property="Visibility" Value="{Binding IsChecked, ElementName=MyCheckBox, Converter={StaticResource BoolToVisualConvertor}}" />
                </Style.Setters>
            </Style>
        </DataGridTextColumn.CellStyle>
    </DataGridTextColumn>
