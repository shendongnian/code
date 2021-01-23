    <Style x:Key="DataGridCellStyle" TargetType="{x:Type DataGridCell}">
        <Style.Triggers>
            <DataTrigger Binding="{Binding Path=., RelativeSource={RelativeSource Self},  Converter={StaticResource DataGridCellToBooleanConverter}, ConverterParameter=IsEnabled}" Value="True">
                <Setter Property="Background" Value="Yellow"/>
            </DataTrigger>
        </Style.Triggers>
    </Style>
        
    <DataGrid CellStyle="{StaticResource DataGridCellStyle}">
       <DataGrid.Columns>
            <DataGridTextColumn Header="MyObject1" Binding="{Binding MyObject1}" />
            <DataGridTextColumn Header="MyObject2" Binding="{Binding MyObject2}" />
       </DataGrid.Columns>
    </DataGrid>
