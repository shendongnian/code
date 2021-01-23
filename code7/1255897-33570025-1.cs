    <Style.Triggers>
        <Trigger Property="IsEnabled" Value="True">
            <Trigger.EnterActions>
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimationUsingKeyFrames
                                        Storyboard.TargetProperty="RenderTransform.Angle"
                                        Duration="0:0:4"
                                        RepeatBehavior="Forever">
                            <DoubleKeyFrameCollection>
                                <DiscreteDoubleKeyFrame KeyTime="0:0:1" Value="90"/>
                                <DiscreteDoubleKeyFrame KeyTime="0:0:2" Value="180"/>
                                <DiscreteDoubleKeyFrame KeyTime="0:0:3" Value="270"/>
                                <DiscreteDoubleKeyFrame KeyTime="0:0:4" Value="360"/>
                            </DoubleKeyFrameCollection>
                       </DoubleAnimationUsingKeyFrames>
                   </Storyboard>
              </BeginStoryboard>
          </Trigger.EnterActions>
      </Trigger>
    </Style.Triggers>
