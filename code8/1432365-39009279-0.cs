    <ComboBox x:Name="combo">
        <ComboBoxItem x:Name="type1" Content="type1" IsSelected="True"></ComboBoxItem>
        <ComboBoxItem x:Name="type2" Content="type2"></ComboBoxItem>
    </ComboBox>
    <CheckBox>
        <CheckBox.Style>
            <Style>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsSelected, ElementName=type2}" Value="True">
                        <Setter Property="CheckBox.IsEnabled" Value="True"></Setter>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding IsSelected, ElementName=type1}" Value="True">
                        <Setter Property="CheckBox.IsEnabled" Value="False"></Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </CheckBox.Style>
    </CheckBox>
