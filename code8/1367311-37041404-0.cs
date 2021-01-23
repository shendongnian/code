    <StackPanel>
        <StackPanel.Resources>
            <Storyboard x:Name="storyboard">
                <DoubleAnimationUsingKeyFrames Storyboard.TargetName="SplashScreenImage" Storyboard.TargetProperty="(UIElement.RenderTransform).(TranslateTransform.Y)"
                    <LinearDoubleKeyFrame KeyTime="0:0:0" Value="50" />
                    <LinearDoubleKeyFrame KeyTime="0:0:2" Value="120" />
                    <LinearDoubleKeyFrame KeyTime="0:0:9" Value="400" />
                </DoubleAnimationUsingKeyFrames>
            </Storyboard>
        </StackPanel.Resources>
        <Canvas>
            <Image x:Name="SplashScreenImage"
                   Loaded="SplashImage_Loaded"
                   Source="Assets/foo600320.jpg">
                <Image.RenderTransform>
                    <TranslateTransform />
                </Image.RenderTransform>
            </Image>              
        </Canvas>
    </StackPanel>       
