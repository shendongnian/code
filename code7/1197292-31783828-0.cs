    <EventTrigger  RoutedEvent="Grid.Loaded"> 
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <ThicknessAnimationUsingKeyFrames Storyboard.TargetProperty="Margin" BeginTime="00:00:00">
                                                <SplineThicknessKeyFrame KeyTime="00:00:00" Value="0,0,0,0" />
                                                <SplineThicknessKeyFrame KeyTime="00:00:02" Value="10,0,0,0" />
                                            </ThicknessAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </EventTrigger>
