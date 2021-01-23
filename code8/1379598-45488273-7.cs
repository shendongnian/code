       <VisualStateGroup x:Name="ValidationState">
                    <VisualState x:Name="InvalidState">
                      <Storyboard>
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ValidationMark"
                                                   Storyboard.TargetProperty="Visibility">
                          <DiscreteObjectKeyFrame KeyTime="0">
                            <DiscreteObjectKeyFrame.Value>
                              <Visibility>Visible</Visibility>
                            </DiscreteObjectKeyFrame.Value>
                          </DiscreteObjectKeyFrame>
                        </ObjectAnimationUsingKeyFrames>
                      </Storyboard>
                    </VisualState>
                    <VisualState x:Name="ValidState">
                      <Storyboard>
                        <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ValidationMark"
                                                   Storyboard.TargetProperty="Visibility">
                          <DiscreteObjectKeyFrame KeyTime="0">
                            <DiscreteObjectKeyFrame.Value>
                              <Visibility>Collapsed</Visibility>
                            </DiscreteObjectKeyFrame.Value>
                          </DiscreteObjectKeyFrame>
                        </ObjectAnimationUsingKeyFrames>
                      </Storyboard>
                    </VisualState>
                  </VisualStateGroup>
