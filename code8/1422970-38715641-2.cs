    <ComboBox x:Name="com_ports"
                ItemsSource="{Binding PortsList}">
        <ComboBox.Resources>
            <local:IsOpenBoldConverter x:Key="IsOpenConverter"/>
        </ComboBox.Resources>
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Path=DisplayName, UpdateSourceTrigger=PropertyChanged}"
                            FontWeight="{Binding Path=IsOpen, UpdateSourceTrigger=PropertyChanged, Converter={StaticResource IsOpenConverter}}"/>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
