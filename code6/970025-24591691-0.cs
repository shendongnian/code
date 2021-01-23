      <Window.Resources>
    		<Storyboard x:Key="open">
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(FrameworkElement.Width)" Storyboard.TargetName="gridDisplay">
    				<EasingDoubleKeyFrame KeyTime="0" Value="0"/>
    				<EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="900"/>
    			</DoubleAnimationUsingKeyFrames>
                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)" Storyboard.TargetName="gridDisplay">
    				<DiscreteObjectKeyFrame KeyTime="0" Value="{x:Static Visibility.Visible}"/>
    			</ObjectAnimationUsingKeyFrames>
    		</Storyboard>
            <Storyboard x:Key="close">
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(FrameworkElement.Width)" Storyboard.TargetName="gridDisplay">
                    <EasingDoubleKeyFrame KeyTime="0" Value="900"/>
                    <EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="0"/>
                </DoubleAnimationUsingKeyFrames>
                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)" Storyboard.TargetName="gridDisplay">
                    <DiscreteObjectKeyFrame KeyTime="0:0:0.6" Value="{x:Static Visibility.Collapsed}"/>
                </ObjectAnimationUsingKeyFrames>
            </Storyboard>
        </Window.Resources>
