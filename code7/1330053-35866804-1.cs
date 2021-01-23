    <Storyboard x:Key="gridLoadingBack">
    <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)" Storyboard.TargetName="Page">
        <EasingDoubleKeyFrame KeyTime="0" Value="1"/>
        <EasingDoubleKeyFrame KeyTime="0:0:1" Value="1">
            <EasingDoubleKeyFrame.EasingFunction>
                <CubicEase EasingMode="EaseOut"/>
            </EasingDoubleKeyFrame.EasingFunction>
        </EasingDoubleKeyFrame>
    </DoubleAnimationUsingKeyFrames>
    <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)" Storyboard.TargetName="Page">
        <EasingDoubleKeyFrame KeyTime="0" Value="1"/>
        <EasingDoubleKeyFrame KeyTime="0:0:1" Value="1"/>
     </DoubleAnimationUsingKeyFrames>
