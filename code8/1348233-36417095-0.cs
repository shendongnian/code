    <VisualStateManager.VisualStateGroups>
                                    <VisualStateGroup x:Name="CommonStates">
                                        <VisualState x:Name="Normal"/>
                                        <VisualState x:Name="PointerOver"/>
                                        <VisualState x:Name="Pressed"/>
                                        <VisualState x:Name="Disabled">
                                          </VisualState>
                                        <VisualState x:Name="Checked">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames
                                                    Storyboard.TargetName="PressedBackground"
                                                    Storyboard.TargetProperty = "Visibility">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="Visible"/>
                                                </ObjectAnimationUsingKeyFrames>
                                               </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="CheckedPointerOver">
                                           
                                        </VisualState>
                                        <VisualState x:Name="CheckedPressed"/>
                                        <VisualState x:Name="CheckedDisabled">
                                        </VisualState>
                                        <VisualState x:Name="Indeterminate"/>
                                        <VisualState x:Name="IndeterminatePointerOver"/>
                                        <VisualState x:Name="IndeterminatePressed"/>
                                        <VisualState x:Name="IndeterminateDisabled">
                                        </VisualState>
                                    </VisualStateGroup>
                                </VisualStateManager.VisualStateGroups>
