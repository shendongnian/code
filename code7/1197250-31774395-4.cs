    <ComboBox Name="cmb1">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Path=ItemName}" />
            </DataTemplate>
        </ComboBox.ItemTemplate>
        <ComboBox.ItemContainerStyle>
            <Style TargetType="ComboBoxItem">
               <Setter Property="IsEnabled" Value="{Binding ItemEnabled}" />
            </Style>
        </ComboBox.ItemContainerStyle>
    </ComboBox>
