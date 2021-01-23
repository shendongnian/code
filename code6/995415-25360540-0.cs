    <StackPanel>
        <StackPanel.Resources>
            <Path x:Key="Test1"/>
            <Path x:Key="Test2"/>
        </StackPanel.Resources>
        <ToggleButton>
            <ToggleButton.Style>
                <Style TargetType="ToggleButton">
                    <Setter Property="Content" Value="{StaticResource Test1}"/>
                    <Style.Triggers>
                        <Trigger Property="IsChecked" Value="True">
                            <Setter Property="Content"
                                    Value="{StaticResource Test2}"/>
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </ToggleButton.Style>
        </ToggleButton>
    </StackPanel>
