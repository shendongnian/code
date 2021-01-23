     <VisualStateManager.VisualStateGroups>
            <VisualStateGroup x:Name="VisualStateGroup">
                <VisualStateGroup.Transitions>
                    <VisualTransition To="StateA">
                        <VisualTransition.Storyboard>
                            <Storyboard>
                                <PopOutThemeAnimation TargetName="SecondElement"/>
                                <PopInThemeAnimation TargetName="FirstElement"/>
                            </Storyboard>
                        </VisualTransition.Storyboard>
                    </VisualTransition>
                    <VisualTransition To="StateB">
                        <VisualTransition.Storyboard>
                            <Storyboard>
                                <PopOutThemeAnimation TargetName="FirstElement"/>
                                <PopInThemeAnimation TargetName="SecondElement"/>
                            </Storyboard>                                               
                         </VisualTransition.Storyboard>
                    </VisualTransition>
                </VisualStateGroup.Transitions>
                <VisualState x:Name="StateA">
                   <VisualState.Setters>
                       <Setter Target="FirstElement.Visibility" Value="Visible" />
                       <Setter Target="SecondElement.Visibility" Value="Collapsed" />
                   </VisualState.Setters>
            </VisualState>
            <VisualState x:Name="StateB">
                <VisualState.Setters>
                    <Setter Target="FirstElement.Visibility" Value="Collapsed" />
                    <Setter Target="SecondElement.Visibility" Value="Visible" />
                </VisualState.Setters>
                
            </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>
