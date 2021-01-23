    <Popup x:Name="popup">
        <Popup.Style>
            <Style>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding PopupOpened}" Value="True">
                        <DataTrigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsOpen">
                                        <DiscreteBooleanKeyFrame KeyTime="00:00:00.00" Value="True" />
                                    </BooleanAnimationUsingKeyFrames>
                                </Storyboard>
                            </BeginStoryboard>
                        </DataTrigger.EnterActions>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Popup.Style>
    
        <TextBlock />
    </Popup>
