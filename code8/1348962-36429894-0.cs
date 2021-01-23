    <ToggleButton>
        <ToggleButton.Style>
            <Style TargetType="ToggleButton">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate>
                            ... IsChecked == false template
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <Trigger Property="IsChecked" Value="True">
                        <Trigger.Setters>
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate>
                                        ... // IsChecked == true template
                                    </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                        </Trigger.Setters>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </ToggleButton.Style>
    </ToggleButton>
