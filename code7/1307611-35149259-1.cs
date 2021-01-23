    <Style x:Key="CustomMetroListBoxItem"
           BasedOn="{StaticResource MetroListBoxItem}"
           TargetType="{x:Type ListBoxItem}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type ListBoxItem}">
                    <Border x:Name="Border"
                            Background="{TemplateBinding Background}"
                            BorderBrush="{TemplateBinding BorderBrush}"
                            BorderThickness="{TemplateBinding BorderThickness}"
                            SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}">
                        <ContentPresenter Margin="{TemplateBinding Padding}"
                                          HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                          VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                                          SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" />
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
        <Style.Triggers>
            <Trigger Property="IsSelected" Value="True">
                <Setter Property="Background" Value="{DynamicResource AccentColorBrush}" />
                <Setter Property="Foreground" Value="{DynamicResource AccentSelectedColorBrush}" />
            </Trigger>
            <Trigger Property="IsMouseOver" Value="True">
                <Setter Property="Background" Value="{DynamicResource AccentColorBrush3}" />
            </Trigger>
            <Trigger Property="IsEnabled" Value="False">
                <Setter Property="Foreground" Value="{DynamicResource GrayBrush7}" />
            </Trigger>
            <MultiTrigger>
                <MultiTrigger.Conditions>
                    <Condition Property="IsEnabled" Value="False" />
                    <Condition Property="IsSelected" Value="True" />
                </MultiTrigger.Conditions>
                <Setter Property="Background" Value="{DynamicResource GrayBrush7}" />
                <Setter Property="Foreground" Value="{DynamicResource AccentSelectedColorBrush}" />
            </MultiTrigger>
            <MultiTrigger>
                <MultiTrigger.Conditions>
                    <Condition Property="IsSelected" Value="True" />
                    <Condition Property="Selector.IsSelectionActive" Value="False" />
                </MultiTrigger.Conditions>
                <Setter Property="Background" Value="{DynamicResource GrayBrush7}" />
            </MultiTrigger>
            <MultiTrigger>
                <MultiTrigger.Conditions>
                    <Condition Property="IsSelected" Value="True" />
                    <Condition Property="Selector.IsSelectionActive" Value="True" />
                </MultiTrigger.Conditions>
                <Setter Property="Background" Value="{DynamicResource AccentColorBrush2}" />
            </MultiTrigger>
        </Style.Triggers>
    </Style>
