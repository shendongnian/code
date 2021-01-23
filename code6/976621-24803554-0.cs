    <VisualState x:Name="Collapsed">
        <Storyboard>
            <DoubleAnimationUsingKeyFrames Duration="0:0:5" Storyboard.TargetProperty="(FrameworkElement.Width)" Storyboard.TargetName="metaGrid">
                <EasingDoubleKeyFrame KeyTime="0" Value="0"/>
            </DoubleAnimationUsingKeyFrames>
            <ObjectAnimationUsingKeyFrames BeginTime="0:0:5" Storyboard.TargetProperty="(UIElement.Visibility)" Storyboard.TargetName="contentControl">
                <DiscreteObjectKeyFrame KeyTime="0" Value="{x:Static Visibility.Collapsed}"/>
            </ObjectAnimationUsingKeyFrames>
        </Storyboard>
    </VisualState>
