    <Storyboard>
       <DoubleAnimationUsingKeyFrames Storyboard.TargetName="MyFirstObject" 
                        Storyboard.TargetProperty="RenderTransform.(RotateTransform.Angle)">
               <EasingDoubleKeyFrame Value="0" KeyTime="0:0:0"/>
               <EasingDoubleKeyFrame Value="360" KeyTime="0:0:2"/>
       </DoubleAnimationUsingKeyFrames>
       <DoubleAnimationUsingKeyFrames Storyboard.TargetName="MySecondObject" 
                        Storyboard.TargetProperty="RenderTransform.(RotateTransform.Angle)">
               <EasingDoubleKeyFrame Value="0" KeyTime="0:0:1"/>
               <EasingDoubleKeyFrame Value="360" KeyTime="0:0:3"/>
       </DoubleAnimationUsingKeyFrames>
    </Storyboard>
