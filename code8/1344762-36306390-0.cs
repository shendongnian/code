     <VisualStateManager.VisualStateGroups>
                    <VisualStateGroup>
                        <VisualState x:Name="wideView">
                            <VisualState.StateTriggers>
                                <triggers:CompositeStateTrigger Operator="And">
                                    <triggers:CompareStateTrigger Value="{x:Bind SelectionList.SelectedIndex, Mode=OneWay}"
                                                      CompareTo="1" Comparison="Equal"/>
                                    <triggers:AdaptiveTrigger MinWindowWidth="960"/>
                                </triggers:CompositeStateTrigger>
                                
                              
                            </VisualState.StateTriggers>
                            <VisualState.Setters>
                                <Setter Target="ListColumn.Width" Value="360"/>
                                <Setter Target="DetailColumn.Width" Value="*"/>
                            </VisualState.Setters>
                        </VisualState>
                        <VisualState x:Name="narrowDetailView">
                            <VisualState.StateTriggers>
                                <triggers:CompositeStateTrigger Operator="And">
                                    <triggers:CompareStateTrigger Value="{x:Bind SelectionList.SelectedIndex, Mode=OneWay}"
                                                      CompareTo="0" Comparison="Equal"/>
                                    <triggers:AdaptiveTrigger MinWindowWidth="0"/>
                                </triggers:CompositeStateTrigger>
                            </VisualState.StateTriggers>
                            <VisualState.Setters>
                                <Setter Target="ListColumn.Width" Value="0"/>
                                <Setter Target="DetailColumn.Width" Value="*"/>
                            </VisualState.Setters>
                        </VisualState>
                        <VisualState x:Name="narrowListView">
                            <VisualState.StateTriggers>
                                <triggers:CompositeStateTrigger Operator="And">
                                    <triggers:AdaptiveTrigger MinWindowWidth="0"/>
                                    <triggers:CompareStateTrigger Value="{x:Bind SelectionList.SelectedIndex, Mode=OneWay}"
                                                      CompareTo="-1" Comparison="Equal"/>
                                </triggers:CompositeStateTrigger>
                            </VisualState.StateTriggers>
                            <VisualState.Setters>
                                <Setter Target="ListColumn.Width" Value="*"/>
                                <Setter Target="DetailColumn.Width" Value="0"/>
                            </VisualState.Setters>
                        </VisualState>
                    </VisualStateGroup>
                </VisualStateManager.VisualStateGroups>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition x:Name="ListColumn" Width="0"/>
                    <ColumnDefinition x:Name="DetailColumn" Width="*"/>
                </Grid.ColumnDefinitions>
                <ListView x:Name="SelectionList"
                  Background="LightBlue"
                  Grid.Column="0"/>
                <ListView x:Name="DetailsList"
                  Background="LightGreen"
                  Grid.Column="1"/>
