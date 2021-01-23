    <DataGrid x:Name="MetroDataGrid"
                Grid.Column="1"
                Grid.Row="1"
                RenderOptions.ClearTypeHint="Enabled"
                TextOptions.TextFormattingMode="Display"
                HeadersVisibility="All"
                Margin="5"
                SelectionUnit="FullRow"
                ItemsSource="{Binding Path=Albums}"
                AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridCheckBoxColumn ElementStyle="{DynamicResource MetroDataGridCheckBox}"
                                    EditingElementStyle="{DynamicResource MetroDataGridCheckBox}"
                                    Header="IsSelected"
                                    Binding="{Binding RelativeSource={RelativeSource AncestorType=DataGridRow}, Path=IsSelected, Mode=OneWay}" />
            <DataGridTextColumn Header="Title"
                                Binding="{Binding Title}" />
            <DataGridTextColumn Header="Artist"
                                Binding="{Binding Artist.Name}" />
            <DataGridTextColumn Header="Genre"
                                Binding="{Binding Genre.Name}" />
            <controls:DataGridNumericUpDownColumn Header="Price"
                                                    Binding="{Binding Price}"
                                                    StringFormat="C"
                                                    Minimum="0" />
        </DataGrid.Columns>
        <DataGrid.Style>
            <Style BasedOn="{StaticResource MetroDataGrid}"
                    TargetType="{x:Type DataGrid}">
                <Setter Property="AlternatingRowBackground"
                        Value="{DynamicResource GrayBrush10}" />
            </Style>
        </DataGrid.Style>
        <DataGrid.RowStyle>
            <Style BasedOn="{StaticResource MetroDataGridRow}"
                    TargetType="{x:Type DataGridRow}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Price, Mode=OneWay, Converter={StaticResource AlbumPriceIsTooMuchConverter}}"
                                    Value="True">
                        <Setter Property="Background"
                                Value="#FF8B8B" />
                        <Setter Property="Foreground"
                                Value="Red" />
                    </DataTrigger>
                    <!-- IsMouseOver -->
                    <MultiDataTrigger>
                        <MultiDataTrigger.Conditions>
                            <Condition Binding="{Binding Price, Mode=OneWay, Converter={StaticResource AlbumPriceIsTooMuchConverter}}"
                                        Value="True" />
                            <Condition Binding="{Binding Path=IsMouseOver, RelativeSource={RelativeSource Self}}"
                                        Value="true" />
                        </MultiDataTrigger.Conditions>
                        <Setter Property="Background"
                                Value="#FFBDBD" />
                    </MultiDataTrigger>
                </Style.Triggers>
            </Style>
        </DataGrid.RowStyle>
        <DataGrid.RowValidationRules>
            <ValueConverter:AlbumPriceIsReallyTooMuchValidation ValidatesOnTargetUpdated="True"
                                                                ValidationStep="CommittedValue" />
            <ValueConverter:AlbumPriceIsReallyTooMuchValidation ValidatesOnTargetUpdated="True"
                                                                ValidationStep="UpdatedValue" />
        </DataGrid.RowValidationRules>
    </DataGrid>
