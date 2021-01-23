    <DataGridTextColumn Binding="{Binding MyObject}">
        <DataGridTextColumn.CellStyle>
            <Style TargetType="DataGridCell">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding MyObject.IsEnabled, PresentationTraceSources.TraceLevel=High, Converter={StaticResource debugger}}"  Value="False">
                        <!-- some setters -->
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </DataGridTextColumn.CellStyle>
    </DataGridTextColumn>
