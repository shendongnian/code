    <TextBox Background="LightGreen" Width="100" Height="100" BorderBrush="Green">
                <TextBox.Style>
                    <Style TargetType="TextBox">
                        <Style.Triggers>
                            <Trigger Property="IsFocused" Value="True">
                                <Trigger.EnterActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <ThicknessAnimation Duration="0:0:0.400" To="3" Storyboard.TargetProperty="BorderThickness" />
                                            <DoubleAnimation Duration="0:0:0.300" To="125" Storyboard.TargetProperty="Height" />
                                            <DoubleAnimation Duration="0:0:0.300" To="125" Storyboard.TargetProperty="Width" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.EnterActions>
                                <Trigger.ExitActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <ThicknessAnimation Duration="0:0:0.250" To="0" Storyboard.TargetProperty="BorderThickness" />
                                            <DoubleAnimation Duration="0:0:0.150" To="100" Storyboard.TargetProperty="Height" />
                                            <DoubleAnimation Duration="0:0:0.150" To="100" Storyboard.TargetProperty="Width" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.ExitActions>
                            </Trigger>
                        </Style.Triggers>
                    </Style>
                </TextBox.Style>
            </TextBox>
