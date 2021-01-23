    <Frame x:Name="Frm" Width="499" Height="248" Content="Frame"  Navigating="Frame_Navigating_1" BorderThickness="2" BorderBrush="#FF21BD9A">
        <Frame.RenderTransform>
            <TranslateTransform x:Name="TransTrfm" />
        </Frame.RenderTransform>
        <Frame.Resources>
            <Storyboard x:Key="SbKey">
                <DoubleAnimationUsingKeyFrames  Storyboard.TargetProperty="Opacity">
                    <DoubleAnimationUsingKeyFrames.KeyFrames>
                        <LinearDoubleKeyFrame KeyTime="0:0:0" Value="1.0"/>
                        <LinearDoubleKeyFrame KeyTime="0:0:0.1" Value="0"/>
                    </DoubleAnimationUsingKeyFrames.KeyFrames>
                </DoubleAnimationUsingKeyFrames>
    
                <DoubleAnimationUsingKeyFrames BeginTime="0:0:0.15" Storyboard.TargetProperty="X" Storyboard.TargetName="TransTrfm">
                    <DoubleAnimationUsingKeyFrames.KeyFrames>
                        <LinearDoubleKeyFrame  KeyTime="0:0:0" Value="0.0" />
                        <LinearDoubleKeyFrame  KeyTime="0:0:0.17" Value="-1000.0" />
                        <LinearDoubleKeyFrame  KeyTime="0:0:0.2" Value="0.0" />
                    </DoubleAnimationUsingKeyFrames.KeyFrames>
                </DoubleAnimationUsingKeyFrames>
                
                <DoubleAnimationUsingKeyFrames BeginTime="0:0:0.35" Storyboard.TargetProperty="Opacity">
                    <DoubleAnimationUsingKeyFrames.KeyFrames>
                        <LinearDoubleKeyFrame KeyTime="0:0:0" Value="1.0"/>
                    </DoubleAnimationUsingKeyFrames.KeyFrames>
                </DoubleAnimationUsingKeyFrames>
                
            </Storyboard>
        </Frame.Resources>
    </Frame>
