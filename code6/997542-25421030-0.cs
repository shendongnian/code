    <toolkit:DataGridTemplateColumn Header="Template">
        <toolkit:DataGridTemplateColumn.CellTemplate>
            <DataTemplate>
                <ComboBox>
                    <ComboBox.ItemTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <CheckBox IsChecked="{Binding IsChecked}" Width="20" />
                                <TextBlock Text="{Binding Program}" Width="100" />
                            </StackPanel>
                        </DataTemplate>
                    </ComboBox.ItemTemplate>
                </ComboBox>
            </DataTemplate>
        </toolkit:DataGridTemplateColumn.CellTemplate>
    </toolkit:DataGridTemplateColumn>
