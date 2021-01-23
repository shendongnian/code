    <Border Background="#363636"
            BorderThickness="10">
        <TabControl>
            <TabControl.Resources>
                <Style TargetType="TabItem">
                    <Setter Property="TextElement.Foreground"
                            Value="White" />
                    <Setter Property="TextElement.FontSize"
                            Value="16" />
                    <Setter Property="Background"
                            Value="#363636" />
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="TabItem">
                                <Border Background="{TemplateBinding Background}">
                                    <ContentPresenter ContentSource="Header" Margin="10,5" />
                                </Border>
                                <ControlTemplate.Triggers>
                                    <Trigger Property="IsSelected"
                                             Value="true">
                                        <Setter Property="TextElement.Foreground"
                                                Value="Black" />
                                        <Setter Property="Background"
                                                Value="White" />
                                    </Trigger>
                                </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </TabControl.Resources>
            <TabItem Header="red">
                <Label Content="Content goes here..." />
            </TabItem>
            <TabItem Header="green">
                <Label Content="Content goes here..." />
            </TabItem>
            <TabItem Header="blue">
                <Label Content="Content goes here..." />
            </TabItem>
        </TabControl>
    </Border>
