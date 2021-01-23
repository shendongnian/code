    <local:CustomComboBox>
        <local:CustomComboBox.Resources>
            <CollectionViewSource x:Key="GroupedData"
                      Source="{Binding Path=CustomItems}">
                <CollectionViewSource.GroupDescriptions>
                    <PropertyGroupDescription PropertyName="GroupName" />
                </CollectionViewSource.GroupDescriptions>
            </CollectionViewSource>
        </local:CustomComboBox.Resources>
        <local:CustomComboBox.Style>
            <Style TargetType="{x:Type local:CustomComboBox}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type local:CustomComboBox}">
                            <Border Background="{TemplateBinding Background}"
                            BorderBrush="{TemplateBinding BorderBrush}"
                            BorderThickness="{TemplateBinding BorderThickness}">
                                <ComboBox IsEditable="True"
                                  Text="{Binding Text}"
                                  ItemsSource="{Binding Source={StaticResource GroupedData}}">                                    
                                </ComboBox>
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </local:CustomComboBox.Style>
    </local:CustomComboBox>
