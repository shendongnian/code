    <DataGrid.Resources>
        <Style TargetType="{x:Type DataGridColumnHeader}">
            <Style.Triggers>
                <Trigger Property="IsMouseOver" Value="True">
                    <Setter Property="ToolTip" 
                            Value="{Binding Path=Column.DisplayIndex, 
                            RelativeSource={RelativeSource Self},
                            Converter={StaticResource IndexToDescriptionConverter}}"/>
                </Trigger>
            </Style.Triggers>
        </Style>
    </DataGrid.Resources>  
