        <xtck:WatermarkComboBox x:Name="cb_Model" ItemsSource="{Binding Models}" SelectedValue="{Binding SelectedModel}"  Watermark="Vehicle Model">
            <xtck:WatermarkComboBox.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Name}" />
                </DataTemplate>
            </xtck:WatermarkComboBox.ItemTemplate>
        </xtck:WatermarkComboBox>
