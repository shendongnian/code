    <DataGridTemplateColumn.CellTemplate>
            <DataTemplate>
                <Image Source="{Binding itemType}" VerticalAlignment="Center">
                 <Image.ToolTip>
                    <ToolTip Visibility="{Binding toolTipText, Converter={StaticResource StringToVisibilityConverter}}">
                      <Border Background="Black" >
                        <TextBlock Text="{Binding toolTipText}" />
                      </Border>
                   </ToolTip>                    
                <Image.ToolTip>
              </Image>
            </DataTemplate>
        </DataGridTemplateColumn.CellTemplate>
