     <Button Content="Content" Background="Red">
            <Button.Style>
                <Style TargetType="Button">
                    <Style.Triggers>
                        <Trigger Property="IsPressed" Value="True">
                            <Trigger.EnterActions>
                                <BeginStoryboard>
                                    <Storyboard>
                                        <ColorAnimation Storyboard.TargetProperty="(Button.Background).(SolidColorBrush.Color)" To="CadetBlue"/>
                                    </Storyboard>
                                </BeginStoryboard>
                            </Trigger.EnterActions>
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
