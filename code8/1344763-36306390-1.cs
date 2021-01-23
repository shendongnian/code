    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" x:Name="MainGrid">
    
        <VisualStateManager.VisualStateGroups>
                <VisualStateGroup>
                    <VisualState x:Name="wideAll">
                        <VisualState.StateTriggers>
                            <triggers:CompositeStateTrigger Operator="And">
                                <triggers:CompareStateTrigger  Value="{x:Bind SelectionList.SelectedIndex,Mode=OneWay}"
                                                          CompareTo="-1" Comparison="GreaterThan"/>
                                <triggers:CompareStateTrigger Value="{x:Bind  Vm.ScreenWidth,Mode=OneWay}"
                                                      CompareTo="960" Comparison="GreaterThan"/>
                            </triggers:CompositeStateTrigger>
                        </VisualState.StateTriggers>
                        <VisualState.Setters>
                            <Setter Target="ListColumn.Width" Value="420"/>
                            <Setter Target="DetailColumn.Width" Value="*"/>
                        </VisualState.Setters>
                    </VisualState>
                    <!--blue-->
                    <VisualState x:Name="narrowOverview">
                        <VisualState.StateTriggers>
                            <triggers:CompositeStateTrigger Operator="And">
                                <triggers:CompareStateTrigger  Value="{x:Bind SelectionList.SelectedIndex,Mode=OneWay}"
                                                          CompareTo="-1" Comparison="Equal"/>
                               <triggers:CompareStateTrigger Value="{x:Bind  Vm.ScreenWidth,Mode=OneWay}"
                                                          CompareTo="960" Comparison="LessThan"/>
                            </triggers:CompositeStateTrigger>
                        </VisualState.StateTriggers>
                        <VisualState.Setters>
                            <Setter Target="ListColumn.Width" Value="*"/>
                            <Setter Target="DetailColumn.Width" Value="0"/>
                        </VisualState.Setters>
                    </VisualState>
                    <!--Green-->
                    <VisualState x:Name="narrowDetails">
                        <VisualState.StateTriggers>
                            <triggers:CompositeStateTrigger Operator="And">
                                <triggers:CompareStateTrigger  Value="{x:Bind SelectionList.SelectedIndex,Mode=OneWay}"
                                                          CompareTo="2" Comparison="GreaterThan"/>
                                <triggers:CompareStateTrigger Value="{x:Bind Vm.ScreenWidth,Mode=OneWay}"
                                                          CompareTo="960" Comparison="LessThan"/>
                            </triggers:CompositeStateTrigger>
                        </VisualState.StateTriggers>
                        <VisualState.Setters>
                            <Setter Target="ListColumn.Width" Value="0"/>
                            <Setter Target="DetailColumn.Width" Value="*"/>
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateManager.VisualStateGroups>
            <Grid.ColumnDefinitions>
                <ColumnDefinition x:Name="ListColumn" Width="420"/>
                <ColumnDefinition x:Name="DetailColumn" Width="*"/>
            </Grid.ColumnDefinitions>
            <ListView x:Name="SelectionList"
                  Background="LightBlue"
                  Grid.Column="0" >
            </ListView>
            <ListView x:Name="DetailsList"
                  Background="LightGreen"
                  Grid.Column="1" />
        </Grid>
