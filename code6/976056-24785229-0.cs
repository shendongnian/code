    <DataGrid.Columns>
        <DataGridTextColumn Header="MaxLength" Binding="{Binding MaxLength}"
            IsReadOnly="{Binding 
                RelativeSource={RelativeSource AncestorType=DataGrid},
                Path=DataContext.IsMaxLengthEnabled,
                Converter={StaticResource NegateBool}}">
            <DataGridTextColumn.HeaderTemplate>
                <DataTemplate>
                    <CheckBox x:Name="AAOverride" Content="Increase Max Length" 
                        IsChecked="{Binding RelativeSource={RelativeSource AncestorType=DataGrid},
                                    Path=DataContext.IsMaxLengthEnabled,
                                    Mode=TwoWay}"
                     />
                </DataTemplate>
            </DataGridTextColumn.HeaderTemplate>
        </DataGridTextColumn>
    </DataGrid.Columns>
