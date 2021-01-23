    <UserControl ...>
        <Grid>
            <VisualStateManager.VisualStateGroups>
                <VisualStateGroup Name="States">
                    <VisualState x:Name="WithoutObject">
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="WithoutObjectPanel" Storyboard.TargetProperty="Visibility">
                                <DiscreteObjectKeyFrame KeyTime="0:0:0">
                                    <DiscreteObjectKeyFrame.Value>
                                        <Visibility>Visible</Visibility>
                                    </DiscreteObjectKeyFrame.Value>
                                </DiscreteObjectKeyFrame>
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="WithObjectPanel" Storyboard.TargetProperty="Visibility">
                                <DiscreteObjectKeyFrame KeyTime="0:0:0">
                                    <DiscreteObjectKeyFrame.Value>
                                        <Visibility>Collapsed</Visibility>
                                    </DiscreteObjectKeyFrame.Value>
                                </DiscreteObjectKeyFrame>
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </VisualState>
                    <VisualState x:Name="WithObject">
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="WithoutObjectPanel" Storyboard.TargetProperty="Visibility">
                                <DiscreteObjectKeyFrame KeyTime="0:0:0">
                                    <DiscreteObjectKeyFrame.Value>
                                        <Visibility>Collapsed</Visibility>
                                    </DiscreteObjectKeyFrame.Value>
                                </DiscreteObjectKeyFrame>
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="WithObjectPanel" Storyboard.TargetProperty="Visibility">
                                <DiscreteObjectKeyFrame KeyTime="0:0:0">
                                    <DiscreteObjectKeyFrame.Value>
                                        <Visibility>Visible</Visibility>
                                    </DiscreteObjectKeyFrame.Value>
                                </DiscreteObjectKeyFrame>
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateManager.VisualStateGroups>
            
            <StackPanel x:Name="WithoutObjectPanel" Visibility="Hidden">
                <TextBlock Text="Without object :("/>
            </StackPanel>
    
            <StackPanel x:Name="WithObjectPanel" Visibility="Visible">
                <TextBlock Text="With object :) !!!!"/>
            </StackPanel>
        </Grid>
    </UserControl>
