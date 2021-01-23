    <DataGrid xmlns:l="clr-namespace:CSharpWPF">
        <DataGrid.Resources>
            <l:SignConverter x:Key="SignConverter" />
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTextColumn Header="Numeric Value"
                                Binding="{Binding}">
                <DataGridTextColumn.CellStyle>
                    <Style TargetType="DataGridCell">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding Converter={StaticResource SignConverter}}"
                                         Value="-1">
                                <Setter Property="Foreground"
                                        Value="Red" />
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </DataGridTextColumn.CellStyle>
            </DataGridTextColumn>
            <DataGridTextColumn Header="String Value"
                                Binding="{Binding SomeProperty,FallbackValue=String Value}" />
        </DataGrid.Columns>
        <sys:Double>-13</sys:Double>
        <sys:Double>13</sys:Double>
        <sys:Double>-1</sys:Double>
        <sys:Double>-3</sys:Double>
        <sys:Double>3</sys:Double>
        <sys:Double>0</sys:Double>
    </DataGrid>
