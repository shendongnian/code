    <Trigger Property="IsPressed" Value="False">
                        <Trigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <ColorAnimation Storyboard.TargetProperty="(Button.Background).(SolidColorBrush.Color)" To="OriginalColor"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </Trigger.EnterActions>
                    </Trigger>
