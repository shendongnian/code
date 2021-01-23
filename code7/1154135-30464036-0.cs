    <DataGrid.Resources>
    <Style TargetType="DataGridCell">
          <Setter Property="ToolTip" >
                <Setter.Value>
                 <MultiBinding Converter="{StaticResource ToolTipConverter}">
                      <Binding Path="RowID" />
                      <Binding Path="BusinessPhone" />
                 </MultiBinding>
              </Setter.Value>
        </Setter>
       </Style>
    </DataGrid.Resources>
