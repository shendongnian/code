    <ComboBox
        ...
        x:Name="ComboBoxA"
        ...
        >
        <ComboBox.ItemContainerStyle>
            <Style TargetType="ComboBoxItem">
                <Style.Triggers>
                    <DataTrigger Value="True">
                        <DataTrigger.Binding>
                            <MultiBinding 
                                Converter="{local:ObjectEquals}"
                                >
                                <Binding 
                                    Path="SelectedItem" 
                                    ElementName="ComboBoxB" />
                                <!-- Binding with no properties just binds to the DataContext -->
                                <Binding />
                            </MultiBinding>
                        </DataTrigger.Binding>
                        <Setter 
                            Property="Visibility" 
                            Value="Collapsed" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ComboBox.ItemContainerStyle>
    </ComboBox>
