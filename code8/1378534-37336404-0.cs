    <DataGridTextColumn Header="Column 1 Data" Binding="{Binding Column1Data}" Width="Auto">
        <DataGridTextColumn.HeaderTemplate>
            <DataTemplate>
                <TextBlock Name="Header1TextBlock" Text="{TemplateBinding Content}">
                    <TextBlock.ContextMenu>
                        <ContextMenu>
                            <CheckBox Name="Header1Checkbox" Content="Header Menu 1" IsChecked="{Binding DataContext.Column1Checked, RelativeSource={RelativeSource AncestorType=Window}, Mode=TwoWay}"/>
                        </ContextMenu>
                    </TextBlock.ContextMenu>
                </TextBlock>
            </DataTemplate>
        </DataGridTextColumn.HeaderTemplate>
    </DataGridTextColumn>
            
