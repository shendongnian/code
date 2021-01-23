    <TimelineCollection x:Key="Ani">
                <DoubleAnimationUsingKeyFrames 
                    
                    Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)" 
                                               Storyboard.TargetName="{Binding}"
                                               RepeatBehavior="Forever">
                    <EasingDoubleKeyFrame KeyTime="0:0:1" 
                                          Value="360"/>
                </DoubleAnimationUsingKeyFrames>
    </TimelineCollection>
