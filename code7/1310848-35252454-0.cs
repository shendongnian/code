      <ScrollViewer ScrollViewer.VerticalScrollBarVisibility="Hidden" Margin="0,5,0,0" Grid.Row="1">
        <StackPanel.Triggers>
            <EventTrigger RoutedEvent="ButtonBase.Click" SourceName="btnRestartWiFi1_Copy19">
                <BeginStoryboard>
                    <Storyboard>
                        <!--<DoubleAnimation Storyboard.TargetName="Stk1" Storyboard.TargetProperty="Opacity" To="0"/>-->
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility">
                            <ObjectAnimationUsingKeyFrames.KeyFrames>
                                <DiscreteObjectKeyFrame Value="{x:Static local:ViewModel.Collapsed}">
                                </DiscreteObjectKeyFrame>
                            </ObjectAnimationUsingKeyFrames.KeyFrames>
                        </ObjectAnimationUsingKeyFrames>                            
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </StackPanel.Triggers>
       <StackPanel x:Name="MenuAppMemTopApps1" Height="485" Width="534">
       ...
