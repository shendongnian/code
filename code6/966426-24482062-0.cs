                              <ControlTemplate.Triggers>
                                    <EventTrigger RoutedEvent="Button.MouseEnter">
                                        <BeginStoryboard>
                                            <Storyboard>
                                                <ColorAnimation  Storyboard.TargetName="border" AutoReverse="True"  
                                                                 Storyboard.TargetProperty="(Border.Background).(SolidColorBrush.Color)" 
                                                                 To="Blue" RepeatBehavior="Forever" Duration="0:0:1"/>
                                            </Storyboard>
                                        </BeginStoryboard>
                                    </EventTrigger>
                                    <Trigger Property="IsPressed" Value="True">
                                        <Setter Property="Background" TargetName="border" Value="GreenYellow"/>
                                    </Trigger>
                                    <!--<Trigger Property="IsMouseOver" Value="True">
                                        <Setter Property="Background" TargetName="border" Value="Gray"/>
                                    </Trigger>-->
                                    <Trigger Property="IsEnabled" Value="False">
                                        <Setter Property="Opacity" TargetName="grid" Value="0.25"/>
                                    </Trigger>
                                </ControlTemplate.Triggers>  
 
